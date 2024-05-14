namespace ApplicationManagement.SharedTestHelpers.Fakes.Program;

using AutoBogus;
using ApplicationManagement.Domain.Programs;
using ApplicationManagement.Domain.Programs.Dtos;

public sealed class FakeProgramForUpdateDto : AutoFaker<ProgramForUpdateDto>
{
    public FakeProgramForUpdateDto()
    {
    }
}