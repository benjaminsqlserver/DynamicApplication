namespace ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.DomainEvents;

public sealed class ProgramApplicantCustomQuestionResponseCreated : DomainEvent
{
    public ProgramApplicantCustomQuestionResponse ProgramApplicantCustomQuestionResponse { get; set; } 
}
            