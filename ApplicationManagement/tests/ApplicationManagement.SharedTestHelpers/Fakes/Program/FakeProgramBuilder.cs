namespace ApplicationManagement.SharedTestHelpers.Fakes.Program;

using ApplicationManagement.Domain.Programs;
using ApplicationManagement.Domain.Programs.Models;

public class FakeProgramBuilder
{
    private ProgramForCreation _creationData = new FakeProgramForCreation().Generate();

    public FakeProgramBuilder WithModel(ProgramForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeProgramBuilder WithProgramDescription(string programDescription)
    {
        _creationData.ProgramDescription = programDescription;
        return this;
    }
    
    public Program Build()
    {
        var result = Program.Create(_creationData);
        return result;
    }
}