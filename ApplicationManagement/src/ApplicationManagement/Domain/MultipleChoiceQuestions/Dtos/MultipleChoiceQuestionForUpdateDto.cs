namespace ApplicationManagement.Domain.MultipleChoiceQuestions.Dtos;

using Destructurama.Attributed;

public sealed record MultipleChoiceQuestionForUpdateDto
{
    public string Choice { get; set; }
}
