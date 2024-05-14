namespace ApplicationManagement.Domain.ProgramCustomQuestions.Dtos;

using Destructurama.Attributed;

public sealed record ProgramCustomQuestionDto
{
    public Guid Id { get; set; }
    public string QuestionText { get; set; }
    public bool EnableOther { get; set; }
    public string Other { get; set; }
    public int MaxChoiceAllowed { get; set; }

}
