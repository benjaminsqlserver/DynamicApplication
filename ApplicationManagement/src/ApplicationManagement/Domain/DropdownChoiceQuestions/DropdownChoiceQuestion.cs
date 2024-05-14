namespace ApplicationManagement.Domain.DropdownChoiceQuestions;

using System.ComponentModel.DataAnnotations;
using ApplicationManagement.Domain.ProgramCustomQuestions;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using ApplicationManagement.Exceptions;
using ApplicationManagement.Domain.DropdownChoiceQuestions.Models;
using ApplicationManagement.Domain.DropdownChoiceQuestions.DomainEvents;


public class DropdownChoiceQuestion : BaseEntity
{
    public string Choice { get; private set; }

    public ProgramCustomQuestion ProgramCustomQuestion { get; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static DropdownChoiceQuestion Create(DropdownChoiceQuestionForCreation dropdownChoiceQuestionForCreation)
    {
        var newDropdownChoiceQuestion = new DropdownChoiceQuestion();

        newDropdownChoiceQuestion.Choice = dropdownChoiceQuestionForCreation.Choice;

        newDropdownChoiceQuestion.QueueDomainEvent(new DropdownChoiceQuestionCreated(){ DropdownChoiceQuestion = newDropdownChoiceQuestion });
        
        return newDropdownChoiceQuestion;
    }

    public DropdownChoiceQuestion Update(DropdownChoiceQuestionForUpdate dropdownChoiceQuestionForUpdate)
    {
        Choice = dropdownChoiceQuestionForUpdate.Choice;

        QueueDomainEvent(new DropdownChoiceQuestionUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected DropdownChoiceQuestion() { } // For EF + Mocking
}
