namespace ApplicationManagement.Domain.MultipleChoiceQuestions.DomainEvents;

public sealed class MultipleChoiceQuestionCreated : DomainEvent
{
    public MultipleChoiceQuestion MultipleChoiceQuestion { get; set; } 
}
            