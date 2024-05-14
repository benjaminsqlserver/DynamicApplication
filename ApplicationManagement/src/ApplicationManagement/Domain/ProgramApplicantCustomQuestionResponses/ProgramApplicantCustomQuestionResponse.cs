namespace ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses;

using System.ComponentModel.DataAnnotations;
using ApplicationManagement.Domain.Programs;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using ApplicationManagement.Exceptions;
using ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.Models;
using ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.DomainEvents;


public class ProgramApplicantCustomQuestionResponse : BaseEntity
{
    public string Response { get; private set; }

    public Program Program { get; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static ProgramApplicantCustomQuestionResponse Create(ProgramApplicantCustomQuestionResponseForCreation programApplicantCustomQuestionResponseForCreation)
    {
        var newProgramApplicantCustomQuestionResponse = new ProgramApplicantCustomQuestionResponse();

        newProgramApplicantCustomQuestionResponse.Response = programApplicantCustomQuestionResponseForCreation.Response;

        newProgramApplicantCustomQuestionResponse.QueueDomainEvent(new ProgramApplicantCustomQuestionResponseCreated(){ ProgramApplicantCustomQuestionResponse = newProgramApplicantCustomQuestionResponse });
        
        return newProgramApplicantCustomQuestionResponse;
    }

    public ProgramApplicantCustomQuestionResponse Update(ProgramApplicantCustomQuestionResponseForUpdate programApplicantCustomQuestionResponseForUpdate)
    {
        Response = programApplicantCustomQuestionResponseForUpdate.Response;

        QueueDomainEvent(new ProgramApplicantCustomQuestionResponseUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected ProgramApplicantCustomQuestionResponse() { } // For EF + Mocking
}
