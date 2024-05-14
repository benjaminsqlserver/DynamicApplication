namespace ApplicationManagement.Domain.DropdownChoiceQuestions.Dtos;

using Destructurama.Attributed;

public sealed record DropdownChoiceQuestionForUpdateDto
{
    public string Choice { get; set; }
}
