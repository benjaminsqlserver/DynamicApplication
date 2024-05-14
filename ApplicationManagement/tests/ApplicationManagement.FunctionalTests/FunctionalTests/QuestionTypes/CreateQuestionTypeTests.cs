namespace ApplicationManagement.FunctionalTests.FunctionalTests.QuestionTypes;

using ApplicationManagement.SharedTestHelpers.Fakes.QuestionType;
using ApplicationManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class CreateQuestionTypeTests : TestBase
{
    [Fact]
    public async Task create_questiontype_returns_created_using_valid_dto()
    {
        // Arrange
        var questionType = new FakeQuestionTypeForCreationDto().Generate();

        // Act
        var route = ApiRoutes.QuestionTypes.Create();
        var result = await FactoryClient.PostJsonRequestAsync(route, questionType);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}