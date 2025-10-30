using Moq;
using Xunit;

namespace HannahAI.UnitTests.Application.Users;

public class CreateUserCommandHandlerTests
{
    [Fact]
    public void Handle_Should_CreateUser_WhenRequestIsValid()
    {
        // Arrange
        var mockUserRepo = new Mock<HannahAI.Application.Common.Interfaces.IRepository<HannahAI.Domain.Entities.Users.User>>();
        var mockPasswordHasher = new Mock<HannahAI.Application.Features.Auth.Services.IPasswordHasher>();
        var mockUnitOfWork = new Mock<HannahAI.Application.Common.Interfaces.IUnitOfWork>();
        var mockMapper = new Mock<AutoMapper.IMapper>();

        // Act

        // Assert
    }
}

