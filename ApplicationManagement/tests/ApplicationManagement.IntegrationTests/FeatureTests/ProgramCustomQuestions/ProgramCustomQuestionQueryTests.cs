namespace ApplicationManagement.IntegrationTests.FeatureTests.ProgramCustomQuestions;

using ApplicationManagement.SharedTestHelpers.Fakes.ProgramCustomQuestion;
using ApplicationManagement.Domain.ProgramCustomQuestions.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class ProgramCustomQuestionQueryTests : TestBase
{
    [Fact]
    public async Task can_get_existing_programcustomquestion_with_accurate_props()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var programCustomQuestionOne = new FakeProgramCustomQuestionBuilder().Build();
        await testingServiceScope.InsertAsync(programCustomQuestionOne);

        // Act
        var query = new GetProgramCustomQuestion.Query(programCustomQuestionOne.Id);
        var programCustomQuestion = await testingServiceScope.SendAsync(query);

        // Assert
        programCustomQuestion.QuestionText.Should().Be(programCustomQuestionOne.QuestionText);
        programCustomQuestion.EnableOther.Should().Be(programCustomQuestionOne.EnableOther);
        programCustomQuestion.Other.Should().Be(programCustomQuestionOne.Other);
        programCustomQuestion.MaxChoiceAllowed.Should().Be(programCustomQuestionOne.MaxChoiceAllowed);
    }

    [Fact]
    public async Task get_programcustomquestion_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var query = new GetProgramCustomQuestion.Query(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}