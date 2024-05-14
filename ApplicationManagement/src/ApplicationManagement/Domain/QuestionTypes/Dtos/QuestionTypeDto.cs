namespace ApplicationManagement.Domain.QuestionTypes.Dtos;

using Destructurama.Attributed;

public sealed record QuestionTypeDto
{
    public Guid Id { get; set; }
    public string QuestionTypeName { get; set; }

}
