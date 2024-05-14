namespace ApplicationManagement.Domain.MultipleChoiceQuestions.DomainEvents;

public sealed class MultipleChoiceQuestionUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            