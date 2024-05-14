namespace ApplicationManagement.Domain.ProgramApplicantPersonalInformations.Dtos;

using Destructurama.Attributed;

public sealed record ProgramApplicantPersonalInformationDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Nationality { get; set; }
    public string CurrentResidence { get; set; }
    public string IdNumber { get; set; }
    public string Gender { get; set; }
}
