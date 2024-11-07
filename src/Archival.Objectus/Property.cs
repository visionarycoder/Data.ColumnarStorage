using Archival.Objectus.Base;

namespace Archival.Objectus;

public class Property : Entity
{

    public string Name { get; set; } = null!;
    public string Value { get; set; } = null!;
    public Type ValueType { get; set; } = null!;
    
    public ICollection<Property> Properties { get; } = new List<Property>();

}

public class Property<T> : Property
{

    public new T Value
    {
        get => (T) base.Value;
        set => base.Value = value;
    }

}