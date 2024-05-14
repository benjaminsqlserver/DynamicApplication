namespace ApplicationManagement.IntegrationTests.FeatureTests.ProgramApplicantPersonalInformations;

using ApplicationManagement.SharedTestHelpers.Fakes.ProgramApplicantPersonalInformation;
using ApplicationManagement.Domain.ProgramApplicantPersonalInformations.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class ProgramApplicantPersonalInformationQueryTests : TestBase
{
    [Fact]
    public async Task can_get_existing_programapplicantpersonalinformation_with_accurate_props()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var programApplicantPersonalInformationOne = new FakeProgramApplicantPersonalInformationBuilder().Build();
        await testingServiceScope.InsertAsync(programApplicantPersonalInformationOne);

        // Act
        var query = new GetProgramApplicantPersonalInformation.Query(programApplicantPersonalInformationOne.Id);
        var programApplicantPersonalInformation = await testingServiceScope.SendAsync(query);

        // Assert
        programApplicantPersonalInformation.FirstName.Should().Be(programApplicantPersonalInformationOne.FirstName);
        programApplicantPersonalInformation.LastName.Should().Be(programApplicantPersonalInformationOne.LastName);
        programApplicantPersonalInformation.Email.Should().Be(programApplicantPersonalInformationOne.Email);
        programApplicantPersonalInformation.Phone.Should().Be(programApplicantPersonalInformationOne.Phone);
        programApplicantPersonalInformation.Nationality.Should().Be(programApplicantPersonalInformationOne.Nationality);
        programApplicantPersonalInformation.CurrentResidence.Should().Be(programApplicantPersonalInformationOne.CurrentResidence);
        programApplicantPersonalInformation.IdNumber.Should().Be(programApplicantPersonalInformationOne.IdNumber);
        programApplicantPersonalInformation.Gender.Should().Be(programApplicantPersonalInformationOne.Gender);
    }

    [Fact]
    public async Task get_programapplicantpersonalinformation_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var query = new GetProgramApplicantPersonalInformation.Query(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}