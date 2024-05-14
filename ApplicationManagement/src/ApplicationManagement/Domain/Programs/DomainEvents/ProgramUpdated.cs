namespace ApplicationManagement.Domain.Programs.DomainEvents;

public sealed class ProgramUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            