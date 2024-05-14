namespace ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.Dtos;

using Destructurama.Attributed;

public sealed record ProgramApplicantCustomQuestionResponseForCreationDto
{
    public string Response { get; set; }
}
