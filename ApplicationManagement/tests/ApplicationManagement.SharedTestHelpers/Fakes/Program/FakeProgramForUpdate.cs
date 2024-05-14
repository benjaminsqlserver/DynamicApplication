namespace ApplicationManagement.SharedTestHelpers.Fakes.Program;

using AutoBogus;
using ApplicationManagement.Domain.Programs;
using ApplicationManagement.Domain.Programs.Models;

public sealed class FakeProgramForUpdate : AutoFaker<ProgramForUpdate>
{
    public FakeProgramForUpdate()
    {
    }
}