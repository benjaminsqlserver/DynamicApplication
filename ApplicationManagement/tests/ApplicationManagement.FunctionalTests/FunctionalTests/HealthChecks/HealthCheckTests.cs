namespace ApplicationManagement.FunctionalTests.FunctionalTests.HealthChecks;

using ApplicationManagement.FunctionalTests.TestUtilities;
using System.Net;
using System.Threading.Tasks;

public class HealthCheckTests : TestBase
{
    [Fact]
    public async Task health_check_returns_ok()
    {
        // Arrange
        // N/A

        // Act
        var result = await FactoryClient.GetRequestAsync(ApiRoutes.Health);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}