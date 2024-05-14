namespace ApplicationManagement.Domain.MultipleChoiceQuestions.Dtos;

using Destructurama.Attributed;

public sealed record MultipleChoiceQuestionDto
{
    public Guid Id { get; set; }
    public string Choice { get; set; }
}
