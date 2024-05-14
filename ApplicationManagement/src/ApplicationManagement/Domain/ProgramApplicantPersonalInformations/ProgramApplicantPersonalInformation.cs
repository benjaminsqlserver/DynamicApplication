namespace ApplicationManagement.Domain.ProgramApplicantPersonalInformations;

using System.ComponentModel.DataAnnotations;
using ApplicationManagement.Domain.Programs;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using ApplicationManagement.Exceptions;
using ApplicationManagement.Domain.ProgramApplicantPersonalInformations.Models;
using ApplicationManagement.Domain.ProgramApplicantPersonalInformations.DomainEvents;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

public class ProgramApplicantPersonalInformation : BaseEntity
{
    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string Email { get; private set; }

    public string Phone { get; private set; }

    public string Nationality { get; private set; }

    public string CurrentResidence { get; private set; }

    public string IdNumber { get; private set; }

    [JsonIgnore, IgnoreDataMember]
    public DateTime DateOfBirth { get; private set; }

    public string Gender { get; private set; }

    public Program Program { get; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static ProgramApplicantPersonalInformation Create(ProgramApplicantPersonalInformationForCreation programApplicantPersonalInformationForCreation)
    {
        var newProgramApplicantPersonalInformation = new ProgramApplicantPersonalInformation();

        newProgramApplicantPersonalInformation.FirstName = programApplicantPersonalInformationForCreation.FirstName;
        newProgramApplicantPersonalInformation.LastName = programApplicantPersonalInformationForCreation.LastName;
        newProgramApplicantPersonalInformation.Email = programApplicantPersonalInformationForCreation.Email;
        newProgramApplicantPersonalInformation.Phone = programApplicantPersonalInformationForCreation.Phone;
        newProgramApplicantPersonalInformation.Nationality = programApplicantPersonalInformationForCreation.Nationality;
        newProgramApplicantPersonalInformation.CurrentResidence = programApplicantPersonalInformationForCreation.CurrentResidence;
        newProgramApplicantPersonalInformation.IdNumber = programApplicantPersonalInformationForCreation.IdNumber;
        newProgramApplicantPersonalInformation.Gender = programApplicantPersonalInformationForCreation.Gender;

        newProgramApplicantPersonalInformation.QueueDomainEvent(new ProgramApplicantPersonalInformationCreated(){ ProgramApplicantPersonalInformation = newProgramApplicantPersonalInformation });
        
        return newProgramApplicantPersonalInformation;
    }

    public ProgramApplicantPersonalInformation Update(ProgramApplicantPersonalInformationForUpdate programApplicantPersonalInformationForUpdate)
    {
        FirstName = programApplicantPersonalInformationForUpdate.FirstName;
        LastName = programApplicantPersonalInformationForUpdate.LastName;
        Email = programApplicantPersonalInformationForUpdate.Email;
        Phone = programApplicantPersonalInformationForUpdate.Phone;
        Nationality = programApplicantPersonalInformationForUpdate.Nationality;
        CurrentResidence = programApplicantPersonalInformationForUpdate.CurrentResidence;
        IdNumber = programApplicantPersonalInformationForUpdate.IdNumber;
        Gender = programApplicantPersonalInformationForUpdate.Gender;

        QueueDomainEvent(new ProgramApplicantPersonalInformationUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected ProgramApplicantPersonalInformation() { } // For EF + Mocking
}
