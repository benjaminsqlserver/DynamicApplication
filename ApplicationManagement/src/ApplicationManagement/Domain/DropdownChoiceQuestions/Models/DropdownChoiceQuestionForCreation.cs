namespace ApplicationManagement.Domain.DropdownChoiceQuestions.Models;

using Destructurama.Attributed;

public sealed record DropdownChoiceQuestionForCreation
{
    public string Choice { get; set; }
}
