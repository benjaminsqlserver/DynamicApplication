namespace ApplicationManagement.SharedTestHelpers.Fakes.QuestionType;

using ApplicationManagement.Domain.QuestionTypes;
using ApplicationManagement.Domain.QuestionTypes.Models;

public class FakeQuestionTypeBuilder
{
    private QuestionTypeForCreation _creationData = new FakeQuestionTypeForCreation().Generate();

    public FakeQuestionTypeBuilder WithModel(QuestionTypeForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeQuestionTypeBuilder WithQuestionTypeName(string questionTypeName)
    {
        _creationData.QuestionTypeName = questionTypeName;
        return this;
    }
    
    public QuestionType Build()
    {
        var result = QuestionType.Create(_creationData);
        return result;
    }
}