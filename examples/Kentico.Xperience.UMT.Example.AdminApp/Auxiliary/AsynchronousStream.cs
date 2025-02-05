using System.Collections.Concurrent;

namespace Kentico.Xperience.UMT.Example.AdminApp.Auxiliary;

/// <summary>
/// single purpose stream - consumer (read) waits for promised data, implementation of stream abstract class is not complete and is not needed (internal class) 
/// </summary>
internal sealed class AsynchronousStream : Stream
{
    private readonly BlockingCollection<byte[]> blocks;
    private byte[]? currentBlock;
    private int currentBlockIndex;

    public int CachedBlocks => blocks.Count;

    /// <inheritdoc />
    public AsynchronousStream(int streamWriteCountCache) => blocks = new BlockingCollection<byte[]>(streamWriteCountCache);

    /// <inheritdoc />
    public override bool CanTimeout => false;

    private readonly bool canRead = true;

    /// <inheritdoc />
    public override bool CanRead => canRead;

    /// <inheritdoc />
    public override bool CanSeek => false;

    /// <inheritdoc />
    public override bool CanWrite => true;

    /// <inheritdoc />
    public override long Length => throw new NotSupportedException();

    /// <inheritdoc />
    public override void Flush()
    {
    }

    public event Action? ReadProgress;

    public long TotalBytesWritten { get; private set; }
    public long TotalBytesRead { get; private set; }

    public int WriteCount { get; private set; }

    public override long Position
    {
        get => throw new NotSupportedException();
        set => throw new NotSupportedException();
    }

    public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();

    public override void SetLength(long value) => throw new NotSupportedException();

    public override int Read(byte[] buffer, int offset, int count)
    {
        ValidateBufferArgs(buffer, offset, count);

        int bytesRead = 0;
        while (true)
        {
            if (currentBlock != null)
            {
                int copy = Math.Min(count - bytesRead, currentBlock.Length - currentBlockIndex);
                Array.Copy(currentBlock, currentBlockIndex, buffer, offset + bytesRead, copy);
                currentBlockIndex += copy;
                bytesRead += copy;

                if (currentBlock.Length <= currentBlockIndex)
                {
                    currentBlock = null;
                    currentBlockIndex = 0;
                }

                if (bytesRead == count)
                {
                    break;
                }
            }

            if (!blocks.TryTake(out currentBlock, Timeout.Infinite))
            {
                break;
            }
        }

        TotalBytesRead += bytesRead;
        ReadProgress?.Invoke();

        return bytesRead;
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
        ValidateBufferArgs(buffer, offset, count);

        byte[] newBuf = new byte[count];
        Array.Copy(buffer, offset, newBuf, 0, count);
        blocks.Add(newBuf);
        TotalBytesWritten += count;
        WriteCount++;
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        if (disposing)
        {
            blocks.Dispose();
        }
    }

    public override void Close()
    {
        CompleteWriting();
        base.Close();
    }

    public void CompleteWriting() => blocks.CompleteAdding();

    public bool TryCompleteWriting()
    {
        try
        {
            blocks.CompleteAdding();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private static void ValidateBufferArgs(byte[] buffer, int offset, int count)
    {
        if (buffer == null)
        {
            throw new ArgumentNullException(nameof(buffer));
        }

        if (offset < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(offset));
        }

        if (count < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(count));
        }

        if (buffer.Length - offset < count)
        {
            throw new ArgumentException("buffer.Length - offset < count");
        }
    }
}
