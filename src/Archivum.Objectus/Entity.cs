// Entity.cs
namespace Archivum.Objectus;

public class Entity
{

    private readonly List<Property> properties = [];

    public void AddProperty(Property property)
    {
        properties.Add(property);
    }

    public Property? GetProperty(string name)
    {
        return properties.FirstOrDefault(p => p.Name == name);
    }
}