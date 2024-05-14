namespace ApplicationManagement.Domain.Programs.Dtos;

using Destructurama.Attributed;

public sealed record ProgramDto
{
    public Guid Id { get; set; }
    public string ProgramDescription { get; set; }

}
