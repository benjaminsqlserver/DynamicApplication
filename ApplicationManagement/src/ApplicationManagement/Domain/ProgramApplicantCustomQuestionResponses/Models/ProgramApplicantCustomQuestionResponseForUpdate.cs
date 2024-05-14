namespace ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.Models;

using Destructurama.Attributed;

public sealed record ProgramApplicantCustomQuestionResponseForUpdate
{
    public string Response { get; set; }
}
