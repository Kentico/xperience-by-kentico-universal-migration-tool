using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;

using CMS.Core;

using Kentico.Xperience.UMT.Example.AdminApp.Auxiliary;
using Kentico.Xperience.UMT.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Kentico.Xperience.UMT.Example.AdminApp;

public static class ServiceCollectionExtensions
{
    private const string SOURCE = "UMT.Example";

    public static IServiceCollection AddUmtSample(this IServiceCollection services) => services.AddUniversalMigrationToolkit();

    public static IApplicationBuilder UseUmtSample(this IApplicationBuilder app)
    {
        app.UseWebSockets();

        app.Use(async (HttpContext context, RequestDelegate next) =>
        {
            if (context.Request.Path == "/umtsample/ws")
            {
                if (context.WebSockets.IsWebSocketRequest)
                {
                    var importService = context.RequestServices.GetRequiredService<IImportService>();
                    var eventLogService = context.RequestServices.GetRequiredService<IEventLogService>();

                    using var webSocket = await context.WebSockets.AcceptWebSocketAsync();

                    await DownloadAndImport(webSocket, importService, eventLogService);
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                }
            }
            else
            {
                await next(context);
            }
        });

        return app;
    }

    private sealed record Message(string Type, HeaderPayload Payload);

    // ReSharper disable once ClassNeverInstantiated.Local
    private sealed record HeaderPayload(int ByteSize, string? Body);

    private static async Task DownloadAndImport(WebSocket webSocket, IImportService importService, IEventLogService logService)
    {
        int lastPercentage = 0;
        async Task SendProgress(double ratio)
        {
            if (webSocket.State == WebSocketState.Open)
            {
                int percentage = (int)Math.Floor(ratio * 100);
                if (lastPercentage != percentage)
                {
                    lastPercentage = percentage;
                    byte[] payload = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new { type = "progress", payload = System.Text.Json.JsonSerializer.Serialize(percentage) }));
                    await webSocket.SendAsync(new ArraySegment<byte>(payload, 0, payload.Length), WebSocketMessageType.Text, true, CancellationToken.None);
                }
            }
        }

        async Task SendStats(ImportStats stats)
        {
            if (webSocket.State == WebSocketState.Open)
            {
                byte[] payload = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new { type = "stats", payload = System.Text.Json.JsonSerializer.Serialize(stats) }));
                await webSocket.SendAsync(new ArraySegment<byte>(payload, 0, payload.Length), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }

        async Task SendTooFastReport()
        {
            if (webSocket.State == WebSocketState.Open)
            {
                byte[] payload = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new { type = "toofast", payload = $"" }));
                await webSocket.SendAsync(new ArraySegment<byte>(payload, 0, payload.Length), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }

        async Task SendConfirmHeader()
        {
            if (webSocket.State == WebSocketState.Open)
            {
                byte[] msg = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new { type = "headerConfirmed", payload = "" }));
                await webSocket.SendAsync(new ArraySegment<byte>(msg, 0, msg.Length), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }

        // indicates import start
        var header = (await ReceiveHeader(webSocket)).ToObject<Message>()!.Payload;

        await SendConfirmHeader();

        bool consumerIsRunning = true;
        var ms = new AsynchronousStream(1024 * 32 * 500);
        ms.ReadProgress += () => _ = SendProgress((double)ms.TotalBytesRead / header.ByteSize);
        var stats = new ImportStats();
        var consumerTask = Task.Run(async () =>
        {
            try
            {
                var data = importService.FromJsonStream(ms);

                var observer = new ImportStateObserver();

                observer = await importService.StartImportAsync(data!, observer);

                observer.ImportedInfo += (model, info) =>
                {
                    // lock for the case when import implementation is genuinely parallel
                    lock (stats)
                    {
                        if (!stats.SuccessfulImports.ContainsKey(info.TypeInfo.ObjectType))
                        {
                            stats.SuccessfulImports[info.TypeInfo.ObjectType] = 0;
                        }

                        stats.SuccessfulImports[info.TypeInfo.ObjectType]++;
                    }
                };
                observer.ValidationError += (model, id, validationResults) =>
                {
                    string validationMessage = string.Join("\r\n", validationResults.Select(x => $"{string.Join(", ", x.MemberNames)}: {x.ErrorMessage}"));
                    // lock for the case when import implementation is genuinely parallel
                    lock (stats)
                    {
                        stats.Errors.Add(new(id, ObjectImportErrorKind.ValidationError, validationMessage));
                    }
                };
                observer.Exception += (model, id, exception) =>
                {
                    // lock for the case when import implementation is genuinely parallel
                    lock (stats)
                    {
                        stats.Errors.Add(new(id, ObjectImportErrorKind.Exception, exception.ToString()));
                    }
                };

                await observer.ImportCompletedTask;
            }
            finally
            {
                consumerIsRunning = false;
            }
        });

        var producerTask = Task.Run(async () =>
        {
            WebSocketReceiveResult? receiveResult = null;
            int bufferSize = 1024 * 32;
            int totalReceived = 0;
            while (true)
            {
                if (!consumerIsRunning)
                {
                    break;
                }

                byte[] buffer = new byte[bufferSize];
                receiveResult = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                if (!receiveResult.CloseStatus.HasValue)
                {
                    var data = new ArraySegment<byte>(buffer);

                    if (buffer[0] == 0x2D && buffer.Take(5).All(x => x.Equals(0X2D)))
                    {
                        await ms.FlushAsync();
                        break;
                    }

                    await ms.WriteAsync(data.Array!, data.Offset, receiveResult.Count);
                    await ms.FlushAsync();

                    int count = receiveResult.Count;
                    totalReceived += count;

                    if (ms.CachedBlocks > 3500)
                    {
                        await SendTooFastReport();
                        await Task.Delay(3000);
                    }
                }
                else
                {
                    break;
                }
            }
        });

        bool socketAvailable = true;
        try
        {
            await producerTask;
        }
        catch (SocketException se)
        {
            socketAvailable = false;
            logService.LogException(SOURCE, "PRODUCER", se);
        }
        catch (Exception e)
        {
            logService.LogException(SOURCE, "PRODUCER", e);
        }
        finally
        {
            ms.TryCompleteWriting();
        }

        try
        {
            await consumerTask;
        }
        catch (SocketException se)
        {
            logService.LogException(SOURCE, "CONSUMER", se);
            socketAvailable = false;
        }
        catch (Exception e)
        {
            logService.LogException(SOURCE, "CONSUMER", e);
        }

#pragma warning disable S2589
        if (socketAvailable)
        {
            await SendStats(stats);
            await Task.Delay(1000);
            await webSocket.CloseAsync(
                WebSocketCloseStatus.NormalClosure,
                "Standard closing",
                CancellationToken.None);
        }
    }

    private static async Task<JObject> ReceiveHeader(WebSocket webSocket)
    {
        var ms = new MemoryStream();
        const int bufferSize = 1024 * 32;
        while (true)
        {
            byte[] buffer = new byte[bufferSize];
            var receiveResult = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            if (!receiveResult.CloseStatus.HasValue)
            {
                var data = new ArraySegment<byte>(buffer);

                await ms.WriteAsync(data.Array!, data.Offset, receiveResult.Count);
                await ms.FlushAsync();
            }
            else
            {
                break;
            }

            if (receiveResult.EndOfMessage)
            {
                break;
            }
        }

        ms.Seek(0, SeekOrigin.Begin);

        using var sr = new StreamReader(ms);
        string msg = await sr.ReadToEndAsync();
        var deserialized = JObject.Parse(msg);
        return deserialized;
    }
}

public enum ObjectImportErrorKind
{
    ValidationError,
    Exception
}

public record ObjectImportError(Guid? ObjectId, ObjectImportErrorKind ErrorKind, string Description);

public class ImportStats
{
    public Dictionary<string, int> SuccessfulImports { get; } = [];
    public List<ObjectImportError> Errors { get; } = [];
}
