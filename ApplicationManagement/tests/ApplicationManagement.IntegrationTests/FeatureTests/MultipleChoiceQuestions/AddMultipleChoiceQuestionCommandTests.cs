namespace ApplicationManagement.IntegrationTests.FeatureTests.MultipleChoiceQuestions;

using ApplicationManagement.SharedTestHelpers.Fakes.MultipleChoiceQuestion;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ApplicationManagement.Domain.MultipleChoiceQuestions.Features;

public class AddMultipleChoiceQuestionCommandTests : TestBase
{
    [Fact]
    public async Task can_add_new_multiplechoicequestion_to_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var multipleChoiceQuestionOne = new FakeMultipleChoiceQuestionForCreationDto().Generate();

        // Act
        var command = new AddMultipleChoiceQuestion.Command(multipleChoiceQuestionOne);
        var multipleChoiceQuestionReturned = await testingServiceScope.SendAsync(command);
        var multipleChoiceQuestionCreated = await testingServiceScope.ExecuteDbContextAsync(db => db.MultipleChoiceQuestions
            .FirstOrDefaultAsync(m => m.Id == multipleChoiceQuestionReturned.Id));

        // Assert
        multipleChoiceQuestionReturned.Choice.Should().Be(multipleChoiceQuestionOne.Choice);

        multipleChoiceQuestionCreated.Choice.Should().Be(multipleChoiceQuestionOne.Choice);
    }
}