namespace ApplicationManagement.Domain.QuestionTypes;

using System.ComponentModel.DataAnnotations;
using ApplicationManagement.Domain.ProgramCustomQuestions;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using ApplicationManagement.Exceptions;
using ApplicationManagement.Domain.QuestionTypes.Models;
using ApplicationManagement.Domain.QuestionTypes.DomainEvents;
using ApplicationManagement.Domain.ProgramCustomQuestions;
using ApplicationManagement.Domain.ProgramCustomQuestions.Models;


public class QuestionType : BaseEntity
{
    public string QuestionTypeName { get; private set; }

    private readonly List<ProgramCustomQuestion> _programCustomQuestions = new();
    public IReadOnlyCollection<ProgramCustomQuestion> ProgramCustomQuestions => _programCustomQuestions.AsReadOnly();

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static QuestionType Create(QuestionTypeForCreation questionTypeForCreation)
    {
        var newQuestionType = new QuestionType();

        newQuestionType.QuestionTypeName = questionTypeForCreation.QuestionTypeName;

        newQuestionType.QueueDomainEvent(new QuestionTypeCreated(){ QuestionType = newQuestionType });
        
        return newQuestionType;
    }

    public QuestionType Update(QuestionTypeForUpdate questionTypeForUpdate)
    {
        QuestionTypeName = questionTypeForUpdate.QuestionTypeName;

        QueueDomainEvent(new QuestionTypeUpdated(){ Id = Id });
        return this;
    }

    public QuestionType AddProgramCustomQuestion(ProgramCustomQuestion programCustomQuestion)
    {
        _programCustomQuestions.Add(programCustomQuestion);
        return this;
    }
    
    public QuestionType RemoveProgramCustomQuestion(ProgramCustomQuestion programCustomQuestion)
    {
        _programCustomQuestions.RemoveAll(x => x.Id == programCustomQuestion.Id);
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected QuestionType() { } // For EF + Mocking
}
