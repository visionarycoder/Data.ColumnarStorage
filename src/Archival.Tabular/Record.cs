using Archival.Internal;

namespace Archival.Tabular;

internal class Record : IDisposable
{

    private Guid? datumId;
    private bool disposed = false;

    public object? Value
    {
        get => datumId.HasValue ? Data.Get(datumId.Value).Value : null;
        set
        {
            if (datumId.HasValue)
            {
                Data.Get(datumId.Value).RemoveReference(this);
            }

            if (value == null)
            {
                datumId = null;
            }
            else
            {
                var datum = Data.AddOrGet(value);
                datumId = datum.Id;
                datum.AddReference(this);
            }
        }
    }
    public Type Type => datumId.HasValue ? Data.Get(datumId.Value).Type : typeof(object);
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

    public string GetString() => GetValue<string>();
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
    public byte[] GetBytes() => GetValue<byte[]>();

    // Implement IDisposable
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposed)
        {
            return;
        }

        if (disposing)
        {
            // Release managed resources
            if (datumId.HasValue)
            {
                Data.Get(datumId.Value).RemoveReference(this);
                datumId = null;
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