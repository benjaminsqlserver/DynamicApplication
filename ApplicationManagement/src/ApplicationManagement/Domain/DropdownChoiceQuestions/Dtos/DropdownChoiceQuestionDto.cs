namespace ApplicationManagement.Domain.DropdownChoiceQuestions.Dtos;

using Destructurama.Attributed;

public sealed record DropdownChoiceQuestionDto
{
    public Guid Id { get; set; }
    public string Choice { get; set; }
}
