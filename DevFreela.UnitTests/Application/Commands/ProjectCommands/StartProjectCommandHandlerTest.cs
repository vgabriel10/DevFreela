

using DevFreela.Application.Commands.ProjectCommands.StartProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;

namespace DevFreela.UnitTests.Application.Commands.ProjectCommands
{
    public class StartProjectCommandHandlerTest
    {
        [Fact]
        public async Task GivenValidProject_WhenStartingProject_ThenSetStartInProgress()
        {
            // Arrange
            var project = new Project("teste", "descricao", 1, 2, 1000);
            var projectMock = new Mock<Project>();

            const int ProjectId = 1;

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(pr => pr.GetById(ProjectId)).ReturnsAsync(projectMock.Object);

            var startProjectCommand = new StartProjectCommand(ProjectId);
            var startProjectCommandHandler = new StartProjectHandler(projectRepositoryMock.Object);
            // Act
            var result = await startProjectCommandHandler.Handle(startProjectCommand, new CancellationToken());

            // Assert
            Assert.NotNull(result);
            Assert.True(result.IsSucess);

            projectRepositoryMock.Verify(p => p.Update(It.IsAny<Project>()), Times.Once);
            //projectMock.Verify(p => p.Start(), Times.Once);

        }
    }
}
