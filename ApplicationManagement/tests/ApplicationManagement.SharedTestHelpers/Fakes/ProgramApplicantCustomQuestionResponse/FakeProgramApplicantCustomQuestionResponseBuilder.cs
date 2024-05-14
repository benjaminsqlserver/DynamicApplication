namespace ApplicationManagement.SharedTestHelpers.Fakes.ProgramApplicantCustomQuestionResponse;

using ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses;
using ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.Models;

public class FakeProgramApplicantCustomQuestionResponseBuilder
{
    private ProgramApplicantCustomQuestionResponseForCreation _creationData = new FakeProgramApplicantCustomQuestionResponseForCreation().Generate();

    public FakeProgramApplicantCustomQuestionResponseBuilder WithModel(ProgramApplicantCustomQuestionResponseForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeProgramApplicantCustomQuestionResponseBuilder WithResponse(string response)
    {
        _creationData.Response = response;
        return this;
    }
    
    public ProgramApplicantCustomQuestionResponse Build()
    {
        var result = ProgramApplicantCustomQuestionResponse.Create(_creationData);
        return result;
    }
}