namespace ApplicationManagement.Domain.Programs.Models;

using Destructurama.Attributed;

public sealed record ProgramForUpdate
{
    public string ProgramDescription { get; set; }

}
