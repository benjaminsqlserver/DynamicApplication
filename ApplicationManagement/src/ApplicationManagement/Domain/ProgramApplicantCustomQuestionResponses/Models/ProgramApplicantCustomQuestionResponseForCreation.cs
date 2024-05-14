namespace ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.Models;

using Destructurama.Attributed;

public sealed record ProgramApplicantCustomQuestionResponseForCreation
{
    public string Response { get; set; }
}
