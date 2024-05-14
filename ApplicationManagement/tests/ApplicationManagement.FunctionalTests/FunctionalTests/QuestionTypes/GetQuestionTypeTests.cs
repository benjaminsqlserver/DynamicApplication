namespace ApplicationManagement.FunctionalTests.FunctionalTests.QuestionTypes;

using ApplicationManagement.SharedTestHelpers.Fakes.QuestionType;
using ApplicationManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class GetQuestionTypeTests : TestBase
{
    [Fact]
    public async Task get_questiontype_returns_success_when_entity_exists()
    {
        // Arrange
        var questionType = new FakeQuestionTypeBuilder().Build();
        await InsertAsync(questionType);

        // Act
        var route = ApiRoutes.QuestionTypes.GetRecord(questionType.Id);
        var result = await FactoryClient.GetRequestAsync(route);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}