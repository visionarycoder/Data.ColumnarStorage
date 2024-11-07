#pragma warning disable CS8604 // Possible null reference argument.
namespace Archival.Internal;

public static class Data
{
    private static readonly HashSet<Datum> dataStore = [];

    public static Datum AddOrGet<T>(T value) where T : new()
    {
        var entry = dataStore.FirstOrDefault(d => d.Value.Equals(value));
        if (entry != null)
        {
            return entry;
        }
        entry = new Datum<T>(value);
        dataStore.Add(entry);
        return entry;
    }

    public static void Remove(Guid id)
    {
        var entry = dataStore.FirstOrDefault(d => d.Id == id);
        if (entry == null)
        {
            throw new KeyNotFoundException($"Datum with ID '{id}' not found.");
        }
        dataStore.Remove(entry);
    }

    public static Datum Get(Guid id)
    {
        var entry = dataStore.FirstOrDefault(d => d.Id == id);
        if (entry == null)
        {
            throw new KeyNotFoundException($"Datum with ID '{id}' not found.");
        }
        return entry;
    }

    public class Datum
    {
        public Guid Id { get; } = Guid.NewGuid();
        public object Value { get; }
        public Type Type => Value.GetType();
        private readonly List<WeakReference<object>> references = [];

        public Datum(object value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public void AddReference(object reference)
        {
            references.Add(new WeakReference<object>(reference));
        }

        public void RemoveReference(object reference)
        {
            references.RemoveAll(wr => !wr.TryGetTarget(out var target) || target == reference);
            if (!references.Any(wr => wr.TryGetTarget(out _)))
            {
                Data.Remove(Id);
            }
        }
    }

    public class Datum<T>(T value) : Datum(value)
        where T : new()
    {
        public new T Value { get; } = value;
    }
}
