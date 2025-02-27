

using DevFreela.Application.Commands.ProjectCommands.InsertComment;
using DevFreela.Application.Commands.UserCommands.InsertUserSkill;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;

namespace DevFreela.UnitTests.Application.Commands.UserCommands
{
    public class InsertUserSkillCommandHandlerTest
    {
        [Fact]
        public async Task Given_ValidUserAndSkill_When_AddingSkillToUser_Then_ShouldBeAddedSuccessfully()
        {
            // Arrange
            var user = new User("User 1", "userteste@email.com", new DateTime(2000, 12, 01), "123", "client");
            var userRepositoryMock = new Mock<IUserRepository>();

            var insertUserSkillCommand = new InsertUserSkillCommand(1, 1);
            var insertUserSkillCommandHandler = new InsertUserSkillHandler(userRepositoryMock.Object);

            // Act

            var result = await insertUserSkillCommandHandler.Handle(insertUserSkillCommand, new CancellationToken());

            // Assert
            Assert.NotNull(result);
            Assert.True(result.IsSucess);

            userRepositoryMock.Verify(u => u.InsertUserSkill(It.IsAny<UserSkill>()), Times.Once);
        }

        [Fact]
        public async Task Given_RepositoryThrowsException_When_AddingSkillToUser_Then_ShouldThrowException()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock
                .Setup(u => u.InsertUserSkill(It.IsAny<UserSkill>()))
                .ThrowsAsync(new Exception("Database error"));

            var insertUserSkillCommand = new InsertUserSkillCommand(1, 1);
            var insertUserSkillCommandHandler = new InsertUserSkillHandler(userRepositoryMock.Object);

            // Act e Assert
            var exception = await Assert.ThrowsAsync<Exception>(() =>
                insertUserSkillCommandHandler.Handle(insertUserSkillCommand, new CancellationToken()));

            Assert.Equal("Database error", exception.Message);
        }
    }
}
