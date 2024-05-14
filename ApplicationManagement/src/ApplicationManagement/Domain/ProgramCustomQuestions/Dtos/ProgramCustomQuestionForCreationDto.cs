namespace ApplicationManagement.Domain.ProgramCustomQuestions.Dtos;

using Destructurama.Attributed;

public sealed record ProgramCustomQuestionForCreationDto
{
    public string QuestionText { get; set; }
    public bool EnableOther { get; set; }
    public string Other { get; set; }
    public int MaxChoiceAllowed { get; set; }

}
