using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace HannahAI.IntegrationTests.Api;

public class UsersControllerTests // : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    // public UsersControllerTests(CustomWebApplicationFactory<Program> factory)
    // {
    //     _client = factory.CreateClient();
    // }

    [Fact]
    public async Task GetUserById_WithValidId_ReturnsOk()
    {
        // Arrange

        // Act

        // Assert
    }
}

