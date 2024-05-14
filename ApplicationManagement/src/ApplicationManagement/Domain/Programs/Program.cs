namespace ApplicationManagement.Domain.Programs;

using System.ComponentModel.DataAnnotations;
using ApplicationManagement.Domain.ProgramCustomQuestions;
using ApplicationManagement.Domain.ProgramApplicantPersonalInformations;
using ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using ApplicationManagement.Exceptions;
using ApplicationManagement.Domain.Programs.Models;
using ApplicationManagement.Domain.Programs.DomainEvents;
using ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses;
using ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.Models;
using ApplicationManagement.Domain.ProgramApplicantPersonalInformations;
using ApplicationManagement.Domain.ProgramApplicantPersonalInformations.Models;
using ApplicationManagement.Domain.ProgramCustomQuestions;
using ApplicationManagement.Domain.ProgramCustomQuestions.Models;


public class Program : BaseEntity
{
    public string ProgramDescription { get; private set; }

    private readonly List<ProgramApplicantCustomQuestionResponse> _programApplicantCustomQuestionResponses = new();
    public IReadOnlyCollection<ProgramApplicantCustomQuestionResponse> ProgramApplicantCustomQuestionResponses => _programApplicantCustomQuestionResponses.AsReadOnly();

    private readonly List<ProgramApplicantPersonalInformation> _programApplicantPersonalInformations = new();
    public IReadOnlyCollection<ProgramApplicantPersonalInformation> ProgramApplicantPersonalInformations => _programApplicantPersonalInformations.AsReadOnly();

    private readonly List<ProgramCustomQuestion> _programCustomQuestions = new();
    public IReadOnlyCollection<ProgramCustomQuestion> ProgramCustomQuestions => _programCustomQuestions.AsReadOnly();

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static Program Create(ProgramForCreation programForCreation)
    {
        var newProgram = new Program();

        newProgram.ProgramDescription = programForCreation.ProgramDescription;

        newProgram.QueueDomainEvent(new ProgramCreated(){ Program = newProgram });
        
        return newProgram;
    }

    public Program Update(ProgramForUpdate programForUpdate)
    {
        ProgramDescription = programForUpdate.ProgramDescription;

        QueueDomainEvent(new ProgramUpdated(){ Id = Id });
        return this;
    }

    public Program AddProgramApplicantCustomQuestionResponse(ProgramApplicantCustomQuestionResponse programApplicantCustomQuestionResponse)
    {
        _programApplicantCustomQuestionResponses.Add(programApplicantCustomQuestionResponse);
        return this;
    }
    
    public Program RemoveProgramApplicantCustomQuestionResponse(ProgramApplicantCustomQuestionResponse programApplicantCustomQuestionResponse)
    {
        _programApplicantCustomQuestionResponses.RemoveAll(x => x.Id == programApplicantCustomQuestionResponse.Id);
        return this;
    }

    public Program AddProgramApplicantPersonalInformation(ProgramApplicantPersonalInformation programApplicantPersonalInformation)
    {
        _programApplicantPersonalInformations.Add(programApplicantPersonalInformation);
        return this;
    }
    
    public Program RemoveProgramApplicantPersonalInformation(ProgramApplicantPersonalInformation programApplicantPersonalInformation)
    {
        _programApplicantPersonalInformations.RemoveAll(x => x.Id == programApplicantPersonalInformation.Id);
        return this;
    }

    public Program AddProgramCustomQuestion(ProgramCustomQuestion programCustomQuestion)
    {
        _programCustomQuestions.Add(programCustomQuestion);
        return this;
    }
    
    public Program RemoveProgramCustomQuestion(ProgramCustomQuestion programCustomQuestion)
    {
        _programCustomQuestions.RemoveAll(x => x.Id == programCustomQuestion.Id);
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected Program() { } // For EF + Mocking
}
