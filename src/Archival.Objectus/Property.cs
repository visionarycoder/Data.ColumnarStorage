namespace Archival.Objectus;

public class Property
{
    public required string Name { get; set; }
    public object Value { get; set; } = null!;
    public Type ValueType => Value.GetType();
}

public class Property<T> : Property
{
    public new T Value
    {
        get => (T) base.Value;
        set => base.Value = value;
    }

    public new Type ValueType => typeof(T);

}