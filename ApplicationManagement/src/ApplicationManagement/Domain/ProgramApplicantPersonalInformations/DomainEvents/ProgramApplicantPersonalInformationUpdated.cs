namespace ApplicationManagement.Domain.ProgramApplicantPersonalInformations.DomainEvents;

public sealed class ProgramApplicantPersonalInformationUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            