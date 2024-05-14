namespace ApplicationManagement.IntegrationTests.FeatureTests.DropdownChoiceQuestions;

using ApplicationManagement.SharedTestHelpers.Fakes.DropdownChoiceQuestion;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ApplicationManagement.Domain.DropdownChoiceQuestions.Features;

public class AddDropdownChoiceQuestionCommandTests : TestBase
{
    [Fact]
    public async Task can_add_new_dropdownchoicequestion_to_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var dropdownChoiceQuestionOne = new FakeDropdownChoiceQuestionForCreationDto().Generate();

        // Act
        var command = new AddDropdownChoiceQuestion.Command(dropdownChoiceQuestionOne);
        var dropdownChoiceQuestionReturned = await testingServiceScope.SendAsync(command);
        var dropdownChoiceQuestionCreated = await testingServiceScope.ExecuteDbContextAsync(db => db.DropdownChoiceQuestions
            .FirstOrDefaultAsync(d => d.Id == dropdownChoiceQuestionReturned.Id));

        // Assert
        dropdownChoiceQuestionReturned.Choice.Should().Be(dropdownChoiceQuestionOne.Choice);

        dropdownChoiceQuestionCreated.Choice.Should().Be(dropdownChoiceQuestionOne.Choice);
    }
}