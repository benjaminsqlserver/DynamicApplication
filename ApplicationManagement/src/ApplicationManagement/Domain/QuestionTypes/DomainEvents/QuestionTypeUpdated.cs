namespace ApplicationManagement.Domain.QuestionTypes.DomainEvents;

public sealed class QuestionTypeUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            