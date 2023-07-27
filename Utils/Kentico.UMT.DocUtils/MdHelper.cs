using System.Collections.Concurrent;
using RazorLight;

namespace Kentico.Xperience.UMT;

public static class MdHelper
{
    private static ConcurrentDictionary<string, Task<ITemplatePage>> templates = new();
    public static RazorLightEngine Engine { get; }
    
    static MdHelper()
    {
        var builder = new RazorLightEngineBuilder()
            .EnableDebugMode()
            .UseEmbeddedResourcesProject(typeof(Program).Assembly)
            .UseMemoryCachingProvider();
    
        Engine = builder
            .Build();
    }
    
    public static async Task<string> RenderTemplate<TModel>(string templateKey, TModel model)
    {
        var templateTask = templates.GetOrAdd(templateKey, (tk) => Engine.CompileTemplateAsync(templateKey));
        var template = await templateTask;

        return await Engine.RenderTemplateAsync(template, model);
    }

    public static async Task RenderTemplateToFile<TModel>(string templateKey, TModel model, string filePath)
    {
        string renderResult = await MdHelper.RenderTemplate(
            templateKey,
            model
        );

        Directory.CreateDirectory(Path.GetDirectoryName(filePath) ?? throw new InvalidOperationException("No directory name"));
        await File.WriteAllTextAsync(filePath, renderResult);
    }
}
