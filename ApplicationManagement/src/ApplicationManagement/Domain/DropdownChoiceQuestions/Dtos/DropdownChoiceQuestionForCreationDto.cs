namespace ApplicationManagement.Domain.DropdownChoiceQuestions.Dtos;

using Destructurama.Attributed;

public sealed record DropdownChoiceQuestionForCreationDto
{
    public string Choice { get; set; }
}
