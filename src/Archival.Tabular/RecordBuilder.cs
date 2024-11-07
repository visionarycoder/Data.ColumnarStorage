namespace Archival.Tabular;

internal class RecordBuilder
{
 
    public string? Name { get; private set; }
    public Type? Type { get; private set; }
    public object? Value { get; private set; }

    public RecordBuilder SetName(string name)
    {
        Name = name;
        return this;
    }

    public RecordBuilder SetType(Type type)
    {
        Type = type;
        return this;
    }

    public RecordBuilder SetValue(object? value)
    {
        Value = value;
        return this;
    }

    public Record Build()
    {
        return new Record(this);
    }

}