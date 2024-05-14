namespace ApplicationManagement.SharedTestHelpers.Fakes.ProgramApplicantPersonalInformation;

using ApplicationManagement.Domain.ProgramApplicantPersonalInformations;
using ApplicationManagement.Domain.ProgramApplicantPersonalInformations.Models;

public class FakeProgramApplicantPersonalInformationBuilder
{
    private ProgramApplicantPersonalInformationForCreation _creationData = new FakeProgramApplicantPersonalInformationForCreation().Generate();

    public FakeProgramApplicantPersonalInformationBuilder WithModel(ProgramApplicantPersonalInformationForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeProgramApplicantPersonalInformationBuilder WithFirstName(string firstName)
    {
        _creationData.FirstName = firstName;
        return this;
    }
    
    public FakeProgramApplicantPersonalInformationBuilder WithLastName(string lastName)
    {
        _creationData.LastName = lastName;
        return this;
    }
    
    public FakeProgramApplicantPersonalInformationBuilder WithEmail(string email)
    {
        _creationData.Email = email;
        return this;
    }
    
    public FakeProgramApplicantPersonalInformationBuilder WithPhone(string phone)
    {
        _creationData.Phone = phone;
        return this;
    }
    
    public FakeProgramApplicantPersonalInformationBuilder WithNationality(string nationality)
    {
        _creationData.Nationality = nationality;
        return this;
    }
    
    public FakeProgramApplicantPersonalInformationBuilder WithCurrentResidence(string currentResidence)
    {
        _creationData.CurrentResidence = currentResidence;
        return this;
    }
    
    public FakeProgramApplicantPersonalInformationBuilder WithIdNumber(string idNumber)
    {
        _creationData.IdNumber = idNumber;
        return this;
    }
    
    public FakeProgramApplicantPersonalInformationBuilder WithGender(string gender)
    {
        _creationData.Gender = gender;
        return this;
    }
    
    public ProgramApplicantPersonalInformation Build()
    {
        var result = ProgramApplicantPersonalInformation.Create(_creationData);
        return result;
    }
}