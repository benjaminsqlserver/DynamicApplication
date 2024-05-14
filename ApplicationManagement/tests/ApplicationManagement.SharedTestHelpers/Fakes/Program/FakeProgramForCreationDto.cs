namespace ApplicationManagement.SharedTestHelpers.Fakes.Program;

using AutoBogus;
using ApplicationManagement.Domain.Programs;
using ApplicationManagement.Domain.Programs.Dtos;

public sealed class FakeProgramForCreationDto : AutoFaker<ProgramForCreationDto>
{
    public FakeProgramForCreationDto()
    {
    }
}