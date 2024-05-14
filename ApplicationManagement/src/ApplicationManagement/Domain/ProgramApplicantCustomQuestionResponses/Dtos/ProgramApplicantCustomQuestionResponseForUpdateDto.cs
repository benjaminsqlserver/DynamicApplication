namespace ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.Dtos;

using Destructurama.Attributed;

public sealed record ProgramApplicantCustomQuestionResponseForUpdateDto
{
    public string Response { get; set; }
}
