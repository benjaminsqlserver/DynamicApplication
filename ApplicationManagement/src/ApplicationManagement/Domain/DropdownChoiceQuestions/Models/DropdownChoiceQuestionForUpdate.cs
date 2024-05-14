namespace ApplicationManagement.Domain.DropdownChoiceQuestions.Models;

using Destructurama.Attributed;

public sealed record DropdownChoiceQuestionForUpdate
{
    public string Choice { get; set; }
}
