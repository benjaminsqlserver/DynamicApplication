namespace ApplicationManagement.Domain.MultipleChoiceQuestions.Models;

using Destructurama.Attributed;

public sealed record MultipleChoiceQuestionForUpdate
{
    public string Choice { get; set; }
}
