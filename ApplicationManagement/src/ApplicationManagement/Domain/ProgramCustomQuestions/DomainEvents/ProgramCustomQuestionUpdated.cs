namespace ApplicationManagement.Domain.ProgramCustomQuestions.DomainEvents;

public sealed class ProgramCustomQuestionUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            