namespace ApplicationManagement.Domain.Programs.Dtos;

using Destructurama.Attributed;

public sealed record ProgramForCreationDto
{
    public string ProgramDescription { get; set; }

}
