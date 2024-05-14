namespace ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.Dtos;

using Destructurama.Attributed;

public sealed record ProgramApplicantCustomQuestionResponseDto
{
    public Guid Id { get; set; }
    public string Response { get; set; }
}
