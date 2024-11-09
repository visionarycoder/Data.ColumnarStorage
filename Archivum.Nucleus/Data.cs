namespace Archivum.Nucleus;

using System;
using System.Collections.Concurrent;

public class Data
{

    // Singleton instance of Data
    public static Data Instance { get; } = new Data();

   // ConcurrentDictionary to store unique value mappings
    private readonly ConcurrentDictionary<Guid, object> idValueCollection = [];
    private readonly ConcurrentDictionary<object, Guid> valueIdCollection = [];

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
            return existingId; // Return the existing ID
        }

        // Value does not exist, so create a new Guid ID
        var newId = Guid.NewGuid();

        // Add new entries atomically to both dictionaries
        if (idValueCollection.TryAdd(newId, value) && valueIdCollection.TryAdd(value, newId))
        {
            return newId; // Return the new ID if addition succeeded
        }

        // If there's a race condition where another thread added the value, return the existing ID
        return valueIdCollection[value];
    }

    // Retrieves a value based on its ID
    public object GetValue(Guid id)
    {

        idValueCollection.TryGetValue(id, out var value);
        return value;
    }

    // Removes a value by its ID
    public bool TryRemove(Guid id)
    {
        // Attempt to remove the entry from the idValueCollection
        if (!idValueCollection.TryRemove(id, out var value)) 
            return false;

        // Attempt to remove the corresponding entry from the valueIdCollection
        if (valueIdCollection.TryRemove(value, out _))
        {
            // Both removals succeeded, return true
            return true;
        }
        // Roll back the first removal if the second one failed
        if (!idValueCollection.TryAdd(id, value))
        {
            throw new InvalidOperationException("Failed to roll back removal.");
        }

        // Return false if either removal failed
        return false;
    }
}
