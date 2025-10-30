using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace HannahAI.IntegrationTests.Api;

public class AuthControllerTests // : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    // public AuthControllerTests(CustomWebApplicationFactory<Program> factory)
    // {
    //     _client = factory.CreateClient();
    // }

    [Fact]
    public async Task Login_WithValidCredentials_ReturnsOk()
    {
        // Arrange

        // Act

        // Assert
    }
}

