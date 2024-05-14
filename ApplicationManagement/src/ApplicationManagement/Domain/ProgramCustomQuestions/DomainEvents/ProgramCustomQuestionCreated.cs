namespace ApplicationManagement.Domain.ProgramCustomQuestions.DomainEvents;

public sealed class ProgramCustomQuestionCreated : DomainEvent
{
    public ProgramCustomQuestion ProgramCustomQuestion { get; set; } 
}
            