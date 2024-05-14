namespace ApplicationManagement.IntegrationTests.FeatureTests.ProgramCustomQuestions;

using ApplicationManagement.SharedTestHelpers.Fakes.ProgramCustomQuestion;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ApplicationManagement.Domain.ProgramCustomQuestions.Features;

public class AddProgramCustomQuestionCommandTests : TestBase
{
    [Fact]
    public async Task can_add_new_programcustomquestion_to_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var programCustomQuestionOne = new FakeProgramCustomQuestionForCreationDto().Generate();

        // Act
        var command = new AddProgramCustomQuestion.Command(programCustomQuestionOne);
        var programCustomQuestionReturned = await testingServiceScope.SendAsync(command);
        var programCustomQuestionCreated = await testingServiceScope.ExecuteDbContextAsync(db => db.ProgramCustomQuestions
            .FirstOrDefaultAsync(p => p.Id == programCustomQuestionReturned.Id));

        // Assert
        programCustomQuestionReturned.QuestionText.Should().Be(programCustomQuestionOne.QuestionText);
        programCustomQuestionReturned.EnableOther.Should().Be(programCustomQuestionOne.EnableOther);
        programCustomQuestionReturned.Other.Should().Be(programCustomQuestionOne.Other);
        programCustomQuestionReturned.MaxChoiceAllowed.Should().Be(programCustomQuestionOne.MaxChoiceAllowed);

        programCustomQuestionCreated.QuestionText.Should().Be(programCustomQuestionOne.QuestionText);
        programCustomQuestionCreated.EnableOther.Should().Be(programCustomQuestionOne.EnableOther);
        programCustomQuestionCreated.Other.Should().Be(programCustomQuestionOne.Other);
        programCustomQuestionCreated.MaxChoiceAllowed.Should().Be(programCustomQuestionOne.MaxChoiceAllowed);
    }
}