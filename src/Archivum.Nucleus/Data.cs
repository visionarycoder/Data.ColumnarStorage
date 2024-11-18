namespace Archivum.Nucleus;

using System;
using System.Collections.Concurrent;

public class Data
{
    // Singleton instance of Data
    public static Data Instance { get; } = new();

    // ConcurrentDictionary to store unique value mappings
    private readonly ConcurrentDictionary<Guid, (object Value, int ReferenceCount)> idValueCollection = new();
    private readonly ConcurrentDictionary<object, Guid> valueIdCollection = new();

    // Private constructor to enforce singleton pattern
    private Data()
    {
    }

    // Adds a value if it doesn't already exist, or returns the existing ID
    public Guid AddOrGetId(object value)
    {
        // Check if the value already exists in the valueIdCollection dictionary
        if (valueIdCollection.TryGetValue(value, out var existingId))
        {
            // Increment the reference count
            idValueCollection.AddOrUpdate(existingId, (value, 1), (key, oldValue) => (oldValue.Value, oldValue.ReferenceCount + 1));
            return existingId; // Return the existing ID
        }

        // Value does not exist, so create a new Guid ID
        var newId = Guid.NewGuid();

        // Add new entries atomically to both dictionaries
        if (idValueCollection.TryAdd(newId, (value, 1)) && valueIdCollection.TryAdd(value, newId))
        {
            return newId; // Return the new ID if addition succeeded
        }

        // If there's a race condition where another thread added the value, return the existing ID
        return valueIdCollection[value];
    }

    // Retrieves a value based on its ID
    public object GetValue(Guid id)
    {

        if (!idValueCollection.ContainsKey(id))
            throw new ArgumentException("ID not found.", nameof(id));

        idValueCollection.TryGetValue(id, out var valueTuple);
        return valueTuple.Value;

    }

    // Removes a value by its ID
    public bool TryRemove(Guid id)
    {
        // Attempt to decrement the reference count
        if (idValueCollection.TryGetValue(id, out var valueTuple))
        {
            if (valueTuple.ReferenceCount > 1)
            {
                idValueCollection[id] = (valueTuple.Value, valueTuple.ReferenceCount - 1);
                return true;
            }
        }

        // Attempt to remove the entry from the idValueCollection
        if (!idValueCollection.TryRemove(id, out var removedValueTuple))
            return false;

        // Attempt to remove the corresponding entry from the valueIdCollection
        if (valueIdCollection.TryRemove(removedValueTuple.Value, out _))
        {
            // Both removals succeeded, return true
            return true;
        }

        // Roll back the first removal if the second one failed
        if (!idValueCollection.TryAdd(id, removedValueTuple))
        {
            throw new InvalidOperationException("Failed to roll back removal.");
        }

        // Return false if either removal failed
        return false;
    }
}
