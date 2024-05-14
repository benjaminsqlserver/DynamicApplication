namespace ApplicationManagement.Domain.DropdownChoiceQuestions.DomainEvents;

public sealed class DropdownChoiceQuestionCreated : DomainEvent
{
    public DropdownChoiceQuestion DropdownChoiceQuestion { get; set; } 
}
            