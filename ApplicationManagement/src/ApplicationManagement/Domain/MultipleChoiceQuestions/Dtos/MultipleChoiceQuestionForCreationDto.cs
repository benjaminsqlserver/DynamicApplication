namespace ApplicationManagement.Domain.MultipleChoiceQuestions.Dtos;

using Destructurama.Attributed;

public sealed record MultipleChoiceQuestionForCreationDto
{
    public string Choice { get; set; }
}
