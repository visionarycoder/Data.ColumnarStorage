namespace Archival.Objectus.Base;

public abstract class Entity
{
    public Guid InstanceId { get; } = Guid.NewGuid();
}