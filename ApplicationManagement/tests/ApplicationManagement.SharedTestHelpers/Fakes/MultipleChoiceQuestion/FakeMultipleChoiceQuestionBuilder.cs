namespace ApplicationManagement.SharedTestHelpers.Fakes.MultipleChoiceQuestion;

using ApplicationManagement.Domain.MultipleChoiceQuestions;
using ApplicationManagement.Domain.MultipleChoiceQuestions.Models;

public class FakeMultipleChoiceQuestionBuilder
{
    private MultipleChoiceQuestionForCreation _creationData = new FakeMultipleChoiceQuestionForCreation().Generate();

    public FakeMultipleChoiceQuestionBuilder WithModel(MultipleChoiceQuestionForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeMultipleChoiceQuestionBuilder WithChoice(string choice)
    {
        _creationData.Choice = choice;
        return this;
    }
    
    public MultipleChoiceQuestion Build()
    {
        var result = MultipleChoiceQuestion.Create(_creationData);
        return result;
    }
}