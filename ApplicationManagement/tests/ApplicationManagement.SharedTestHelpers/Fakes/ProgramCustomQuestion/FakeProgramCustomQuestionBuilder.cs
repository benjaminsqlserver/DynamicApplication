namespace ApplicationManagement.SharedTestHelpers.Fakes.ProgramCustomQuestion;

using ApplicationManagement.Domain.ProgramCustomQuestions;
using ApplicationManagement.Domain.ProgramCustomQuestions.Models;

public class FakeProgramCustomQuestionBuilder
{
    private ProgramCustomQuestionForCreation _creationData = new FakeProgramCustomQuestionForCreation().Generate();

    public FakeProgramCustomQuestionBuilder WithModel(ProgramCustomQuestionForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeProgramCustomQuestionBuilder WithQuestionText(string questionText)
    {
        _creationData.QuestionText = questionText;
        return this;
    }
    
    public FakeProgramCustomQuestionBuilder WithEnableOther(bool enableOther)
    {
        _creationData.EnableOther = enableOther;
        return this;
    }
    
    public FakeProgramCustomQuestionBuilder WithOther(string other)
    {
        _creationData.Other = other;
        return this;
    }
    
    public FakeProgramCustomQuestionBuilder WithMaxChoiceAllowed(int maxChoiceAllowed)
    {
        _creationData.MaxChoiceAllowed = maxChoiceAllowed;
        return this;
    }
    
    public ProgramCustomQuestion Build()
    {
        var result = ProgramCustomQuestion.Create(_creationData);
        return result;
    }
}