
using DevFreela.Application.Commands.UserCommands.CreateUser;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using Moq;

namespace DevFreela.UnitTests.Application.Commands.UserCommands
{
    public class CreateUserCommandHandlerTest
    {
        [Fact]
        public async Task GivenValidUser_WhenCreated_ThenCreateSuccessfully()
        {
            // Arrange
            var usuario = new User("User 1", "userteste@email.com", new DateTime(2000, 12, 01), "123", "client");

            var userRepositoryMock = new Mock<IUserRepository>();

            int userIdEsperado = 1;

            userRepositoryMock
                .Setup(ur => ur.CreateUser(It.IsAny<User>()))
                .ReturnsAsync(userIdEsperado);

            var authServiceMock = new Mock<IAuthService>();
            authServiceMock
                .Setup(a => a.ComputeSha256Hash(usuario.Password))
                .Returns("SenhaCriptografada");

            var createUserCommand = new CreateUserCommand
            {
                FullName = "User 1",
                Email = "userteste@email.com",
                BirthDate = new DateTime(2000, 12, 01),
                Password = "123",
                Role = "client"
            };

            var createUserCommandHandler = new CreateUserHandler(userRepositoryMock.Object,authServiceMock.Object);

            // Act
            var result = await createUserCommandHandler.Handle(createUserCommand, new CancellationToken());

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result?.Data);
            Assert.Equal(result.Data, userIdEsperado);

            userRepositoryMock.Verify(ur => ur.CreateUser(It.IsAny<User>()), Times.Once);
        }
    }
}
