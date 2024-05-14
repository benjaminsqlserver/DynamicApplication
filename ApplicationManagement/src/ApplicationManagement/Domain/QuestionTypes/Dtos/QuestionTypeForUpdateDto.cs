namespace ApplicationManagement.Domain.QuestionTypes.Dtos;

using Destructurama.Attributed;

public sealed record QuestionTypeForUpdateDto
{
    public string QuestionTypeName { get; set; }

}
