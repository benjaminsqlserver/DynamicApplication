namespace ApplicationManagement.Domain.QuestionTypes.Dtos;

using Destructurama.Attributed;

public sealed record QuestionTypeForCreationDto
{
    public string QuestionTypeName { get; set; }

}
