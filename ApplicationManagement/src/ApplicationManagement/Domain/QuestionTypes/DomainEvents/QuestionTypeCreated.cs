namespace ApplicationManagement.Domain.QuestionTypes.DomainEvents;

public sealed class QuestionTypeCreated : DomainEvent
{
    public QuestionType QuestionType { get; set; } 
}
            