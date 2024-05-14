namespace ApplicationManagement.Domain.ProgramCustomQuestions.Models;

using Destructurama.Attributed;

public sealed record ProgramCustomQuestionForCreation
{
    public string QuestionText { get; set; }
    public bool EnableOther { get; set; }
    public string Other { get; set; }
    public int MaxChoiceAllowed { get; set; }

}
