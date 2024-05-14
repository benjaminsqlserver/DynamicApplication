namespace ApplicationManagement.Domain.ProgramApplicantPersonalInformations.DomainEvents;

public sealed class ProgramApplicantPersonalInformationCreated : DomainEvent
{
    public ProgramApplicantPersonalInformation ProgramApplicantPersonalInformation { get; set; } 
}
            