namespace ApplicationManagement.IntegrationTests.FeatureTests.QuestionTypes;

using ApplicationManagement.SharedTestHelpers.Fakes.QuestionType;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ApplicationManagement.Domain.QuestionTypes.Features;

public class AddQuestionTypeCommandTests : TestBase
{
    [Fact]
    public async Task can_add_new_questiontype_to_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var questionTypeOne = new FakeQuestionTypeForCreationDto().Generate();

        // Act
        var command = new AddQuestionType.Command(questionTypeOne);
        var questionTypeReturned = await testingServiceScope.SendAsync(command);
        var questionTypeCreated = await testingServiceScope.ExecuteDbContextAsync(db => db.QuestionTypes
            .FirstOrDefaultAsync(q => q.Id == questionTypeReturned.Id));

        // Assert
        questionTypeReturned.QuestionTypeName.Should().Be(questionTypeOne.QuestionTypeName);

        questionTypeCreated.QuestionTypeName.Should().Be(questionTypeOne.QuestionTypeName);
    }
}