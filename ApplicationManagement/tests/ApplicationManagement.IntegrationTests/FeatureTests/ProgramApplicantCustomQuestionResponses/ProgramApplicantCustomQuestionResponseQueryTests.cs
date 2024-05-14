namespace ApplicationManagement.IntegrationTests.FeatureTests.ProgramApplicantCustomQuestionResponses;

using ApplicationManagement.SharedTestHelpers.Fakes.ProgramApplicantCustomQuestionResponse;
using ApplicationManagement.Domain.ProgramApplicantCustomQuestionResponses.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class ProgramApplicantCustomQuestionResponseQueryTests : TestBase
{
    [Fact]
    public async Task can_get_existing_programapplicantcustomquestionresponse_with_accurate_props()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var programApplicantCustomQuestionResponseOne = new FakeProgramApplicantCustomQuestionResponseBuilder().Build();
        await testingServiceScope.InsertAsync(programApplicantCustomQuestionResponseOne);

        // Act
        var query = new GetProgramApplicantCustomQuestionResponse.Query(programApplicantCustomQuestionResponseOne.Id);
        var programApplicantCustomQuestionResponse = await testingServiceScope.SendAsync(query);

        // Assert
        programApplicantCustomQuestionResponse.Response.Should().Be(programApplicantCustomQuestionResponseOne.Response);
    }

    [Fact]
    public async Task get_programapplicantcustomquestionresponse_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var query = new GetProgramApplicantCustomQuestionResponse.Query(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}