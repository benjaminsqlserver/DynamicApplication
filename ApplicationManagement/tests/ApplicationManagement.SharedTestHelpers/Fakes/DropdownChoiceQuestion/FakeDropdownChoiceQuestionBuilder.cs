namespace ApplicationManagement.SharedTestHelpers.Fakes.DropdownChoiceQuestion;

using ApplicationManagement.Domain.DropdownChoiceQuestions;
using ApplicationManagement.Domain.DropdownChoiceQuestions.Models;

public class FakeDropdownChoiceQuestionBuilder
{
    private DropdownChoiceQuestionForCreation _creationData = new FakeDropdownChoiceQuestionForCreation().Generate();

    public FakeDropdownChoiceQuestionBuilder WithModel(DropdownChoiceQuestionForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeDropdownChoiceQuestionBuilder WithChoice(string choice)
    {
        _creationData.Choice = choice;
        return this;
    }
    
    public DropdownChoiceQuestion Build()
    {
        var result = DropdownChoiceQuestion.Create(_creationData);
        return result;
    }
}