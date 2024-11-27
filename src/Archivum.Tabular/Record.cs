using Archivum.Nucleus;
// ReSharper disable UnusedMember.Global

namespace Archivum.Tabular;

internal sealed class Record : IDisposable
{

    private Guid? dataId;
    private bool disposed;

    public object? Value
    {
        get
        {
            if (dataId.HasValue)
            {
                var storedValue = Data.Instance.GetValue(dataId.Value);
                return storedValue == DBNull.Value ? null : storedValue;
            }
            dataId = Data.Instance.AddOrGetId(DBNull.Value);
            return null;
        }
        set
        {
            if (value == null)
                dataId = Data.Instance.AddOrGetId(DBNull.Value);
        }
    }

    public Type Type => dataId.HasValue 
        ? Data.Instance.GetValue(dataId.Value).GetType() 
        : typeof(object);

    public string Name { get; }

    internal Record(RecordBuilder builder)
    {
        Name = builder.Name ?? string.Empty;
        Value = builder.Value;
    }

    public bool IsNull => Value == null || Value == DBNull.Value;

    public T GetValue<T>()
    {
        if (Value == null || Value == DBNull.Value)
        {
            throw new InvalidOperationException("Value is null.");
        }
        return (T)Convert.ChangeType(Value, typeof(T));
    }

    public object GetValue()
    {
        if (Value == null || Value == DBNull.Value)
        {
            throw new InvalidOperationException("Value is null.");
        }
        return Value;
    }

    public string GetString() => GetValue<string>() ?? string.Empty;
    public int GetInt32() => GetValue<int>();
    public bool GetBoolean() => GetValue<bool>();
    public DateTime GetDateTime() => GetValue<DateTime>();
    public double GetDouble() => GetValue<double>();
    public float GetFloat() => GetValue<float>();
    public decimal GetDecimal() => GetValue<decimal>();
    public Guid GetGuid() => GetValue<Guid>();
    public byte GetByte() => GetValue<byte>();
    public short GetInt16() => GetValue<short>();
    public long GetInt64() => GetValue<long>();
    public char GetChar() => GetValue<char>();
    public byte[] GetBytes() => GetValue<byte[]>() ?? Array.Empty<byte>();

    // Implement IDisposable
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (disposed)
        {
            return;
        }

        if (disposing)
        {
            // Release managed resources
            if (dataId.HasValue)
            {
                Data.Instance.TryRemove(dataId.Value);
                dataId = null;
            }
        }
        // Release unmanaged resources if any
        disposed = true;
    }

    ~Record()
    {
        Dispose(false);
    }
}
