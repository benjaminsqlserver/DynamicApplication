namespace ApplicationManagement.Domain.QuestionTypes.Models;

using Destructurama.Attributed;

public sealed record QuestionTypeForCreation
{
    public string QuestionTypeName { get; set; }

}
