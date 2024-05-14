namespace ApplicationManagement.SharedTestHelpers.Fakes.Program;

using AutoBogus;
using ApplicationManagement.Domain.Programs;
using ApplicationManagement.Domain.Programs.Models;

public sealed class FakeProgramForCreation : AutoFaker<ProgramForCreation>
{
    public FakeProgramForCreation()
    {
    }
}