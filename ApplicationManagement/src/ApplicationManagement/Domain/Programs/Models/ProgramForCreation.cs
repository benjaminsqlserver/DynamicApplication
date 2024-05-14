namespace ApplicationManagement.Domain.Programs.Models;

using Destructurama.Attributed;

public sealed record ProgramForCreation
{
    public string ProgramDescription { get; set; }

}
