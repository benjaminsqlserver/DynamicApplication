namespace ApplicationManagement.Domain.MultipleChoiceQuestions;

using System.ComponentModel.DataAnnotations;
using ApplicationManagement.Domain.ProgramCustomQuestions;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using ApplicationManagement.Exceptions;
using ApplicationManagement.Domain.MultipleChoiceQuestions.Models;
using ApplicationManagement.Domain.MultipleChoiceQuestions.DomainEvents;


public class MultipleChoiceQuestion : BaseEntity
{
    public string Choice { get; private set; }

    public ProgramCustomQuestion ProgramCustomQuestion { get; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static MultipleChoiceQuestion Create(MultipleChoiceQuestionForCreation multipleChoiceQuestionForCreation)
    {
        var newMultipleChoiceQuestion = new MultipleChoiceQuestion();

        newMultipleChoiceQuestion.Choice = multipleChoiceQuestionForCreation.Choice;

        newMultipleChoiceQuestion.QueueDomainEvent(new MultipleChoiceQuestionCreated(){ MultipleChoiceQuestion = newMultipleChoiceQuestion });
        
        return newMultipleChoiceQuestion;
    }

    public MultipleChoiceQuestion Update(MultipleChoiceQuestionForUpdate multipleChoiceQuestionForUpdate)
    {
        Choice = multipleChoiceQuestionForUpdate.Choice;

        QueueDomainEvent(new MultipleChoiceQuestionUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected MultipleChoiceQuestion() { } // For EF + Mocking
}
