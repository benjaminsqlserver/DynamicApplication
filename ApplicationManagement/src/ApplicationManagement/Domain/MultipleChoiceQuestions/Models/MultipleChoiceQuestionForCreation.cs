namespace ApplicationManagement.Domain.MultipleChoiceQuestions.Models;

using Destructurama.Attributed;

public sealed record MultipleChoiceQuestionForCreation
{
    public string Choice { get; set; }
}
