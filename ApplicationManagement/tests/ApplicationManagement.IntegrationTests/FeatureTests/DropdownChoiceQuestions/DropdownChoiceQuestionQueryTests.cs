namespace ApplicationManagement.IntegrationTests.FeatureTests.DropdownChoiceQuestions;

using ApplicationManagement.SharedTestHelpers.Fakes.DropdownChoiceQuestion;
using ApplicationManagement.Domain.DropdownChoiceQuestions.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class DropdownChoiceQuestionQueryTests : TestBase
{
    [Fact]
    public async Task can_get_existing_dropdownchoicequestion_with_accurate_props()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var dropdownChoiceQuestionOne = new FakeDropdownChoiceQuestionBuilder().Build();
        await testingServiceScope.InsertAsync(dropdownChoiceQuestionOne);

        // Act
        var query = new GetDropdownChoiceQuestion.Query(dropdownChoiceQuestionOne.Id);
        var dropdownChoiceQuestion = await testingServiceScope.SendAsync(query);

        // Assert
        dropdownChoiceQuestion.Choice.Should().Be(dropdownChoiceQuestionOne.Choice);
    }

    [Fact]
    public async Task get_dropdownchoicequestion_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var query = new GetDropdownChoiceQuestion.Query(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}