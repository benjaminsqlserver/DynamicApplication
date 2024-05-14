namespace ApplicationManagement.Domain.ProgramCustomQuestions;

using System.ComponentModel.DataAnnotations;
using ApplicationManagement.Domain.QuestionTypes;
using ApplicationManagement.Domain.Programs;
using ApplicationManagement.Domain.MultipleChoiceQuestions;
using ApplicationManagement.Domain.DropdownChoiceQuestions;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using ApplicationManagement.Exceptions;
using ApplicationManagement.Domain.ProgramCustomQuestions.Models;
using ApplicationManagement.Domain.ProgramCustomQuestions.DomainEvents;
using ApplicationManagement.Domain.DropdownChoiceQuestions;
using ApplicationManagement.Domain.DropdownChoiceQuestions.Models;
using ApplicationManagement.Domain.MultipleChoiceQuestions;
using ApplicationManagement.Domain.MultipleChoiceQuestions.Models;


public class ProgramCustomQuestion : BaseEntity
{
    public string QuestionText { get; private set; }

    public bool EnableOther { get; private set; }

    public string Other { get; private set; }

    public int MaxChoiceAllowed { get; private set; }

    private readonly List<DropdownChoiceQuestion> _dropdownChoiceQuestions = new();
    public IReadOnlyCollection<DropdownChoiceQuestion> DropdownChoiceQuestions => _dropdownChoiceQuestions.AsReadOnly();

    private readonly List<MultipleChoiceQuestion> _multipleChoiceQuestions = new();
    public IReadOnlyCollection<MultipleChoiceQuestion> MultipleChoiceQuestions => _multipleChoiceQuestions.AsReadOnly();

    public Program Program { get; }

    public QuestionType QuestionType { get; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static ProgramCustomQuestion Create(ProgramCustomQuestionForCreation programCustomQuestionForCreation)
    {
        var newProgramCustomQuestion = new ProgramCustomQuestion();

        newProgramCustomQuestion.QuestionText = programCustomQuestionForCreation.QuestionText;
        newProgramCustomQuestion.EnableOther = programCustomQuestionForCreation.EnableOther;
        newProgramCustomQuestion.Other = programCustomQuestionForCreation.Other;
        newProgramCustomQuestion.MaxChoiceAllowed = programCustomQuestionForCreation.MaxChoiceAllowed;

        newProgramCustomQuestion.QueueDomainEvent(new ProgramCustomQuestionCreated(){ ProgramCustomQuestion = newProgramCustomQuestion });
        
        return newProgramCustomQuestion;
    }

    public ProgramCustomQuestion Update(ProgramCustomQuestionForUpdate programCustomQuestionForUpdate)
    {
        QuestionText = programCustomQuestionForUpdate.QuestionText;
        EnableOther = programCustomQuestionForUpdate.EnableOther;
        Other = programCustomQuestionForUpdate.Other;
        MaxChoiceAllowed = programCustomQuestionForUpdate.MaxChoiceAllowed;

        QueueDomainEvent(new ProgramCustomQuestionUpdated(){ Id = Id });
        return this;
    }

    public ProgramCustomQuestion AddDropdownChoiceQuestion(DropdownChoiceQuestion dropdownChoiceQuestion)
    {
        _dropdownChoiceQuestions.Add(dropdownChoiceQuestion);
        return this;
    }
    
    public ProgramCustomQuestion RemoveDropdownChoiceQuestion(DropdownChoiceQuestion dropdownChoiceQuestion)
    {
        _dropdownChoiceQuestions.RemoveAll(x => x.Id == dropdownChoiceQuestion.Id);
        return this;
    }

    public ProgramCustomQuestion AddMultipleChoiceQuestion(MultipleChoiceQuestion multipleChoiceQuestion)
    {
        _multipleChoiceQuestions.Add(multipleChoiceQuestion);
        return this;
    }
    
    public ProgramCustomQuestion RemoveMultipleChoiceQuestion(MultipleChoiceQuestion multipleChoiceQuestion)
    {
        _multipleChoiceQuestions.RemoveAll(x => x.Id == multipleChoiceQuestion.Id);
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected ProgramCustomQuestion() { } // For EF + Mocking
}
