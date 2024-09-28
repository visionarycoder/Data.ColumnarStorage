namespace Archivum.Internal;

public class Data
{
    public Guid Id { get; } = Guid.NewGuid();
    public object Value { get; set; }
}