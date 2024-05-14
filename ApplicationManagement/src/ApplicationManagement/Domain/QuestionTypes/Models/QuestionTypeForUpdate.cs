namespace ApplicationManagement.Domain.QuestionTypes.Models;

using Destructurama.Attributed;

public sealed record QuestionTypeForUpdate
{
    public string QuestionTypeName { get; set; }

}
