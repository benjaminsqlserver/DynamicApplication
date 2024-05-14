namespace ApplicationManagement.Domain.Programs.DomainEvents;

public sealed class ProgramCreated : DomainEvent
{
    public Program Program { get; set; } 
}
            