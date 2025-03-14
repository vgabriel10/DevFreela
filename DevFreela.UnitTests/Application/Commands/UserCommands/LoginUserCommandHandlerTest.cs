

using DevFreela.Application.Commands.UserCommands.LoginUser;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using Moq;

namespace DevFreela.UnitTests.Application.Commands.UserCommands
{
    public class LoginUserCommandHandlerTest
    {
        [Fact]
        public async Task GivenUserWithValidCredentials_WhenAuthenticate_ThenReturnToken()
        {
            // Arrange
            var email = "teste@gmail.com";
            var password = "123456";
            var passwordHash = "passwordHash";
            var token = "token";
            var role = "client";
            var user = new User("teste", email, new DateTime(2000, 01, 01), password, role);

            var userRepositoryMock = new Mock<IUserRepository>();
            var authServiceMock = new Mock<IAuthService>();

            authServiceMock.Setup(a => a.ComputeSha256Hash(password)).Returns(passwordHash);
            userRepositoryMock.Setup(ur => ur.GetUserByEmailAndPasswordAsync(email, passwordHash)).Returns(Task.FromResult(user));
            authServiceMock.Setup(a => a.GenerateJwtToken(email, role)).Returns(token);

            var loginUserCommand = new LoginUserCommand
            {
                Email = email,
                Password = password
            };

            var loginUserCommandHandler = new LoginUserHandler(authServiceMock.Object, userRepositoryMock.Object);

            // Act
            var result = await loginUserCommandHandler.Handle(loginUserCommand, new CancellationToken());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(result.Email, email);
            Assert.Equal(result.Token, token);

            authServiceMock.Verify(a => a.ComputeSha256Hash(It.IsAny<string>()), Times.Once());
            userRepositoryMock.Verify(ur => ur.GetUserByEmailAndPasswordAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
            authServiceMock.Verify(a => a.GenerateJwtToken(It.IsAny<string>(), It.IsAny<string>()), Times.Once());


        }
    }
}
