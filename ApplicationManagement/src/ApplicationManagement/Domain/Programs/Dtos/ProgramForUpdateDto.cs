namespace ApplicationManagement.Domain.Programs.Dtos;

using Destructurama.Attributed;

public sealed record ProgramForUpdateDto
{
    public string ProgramDescription { get; set; }

}
