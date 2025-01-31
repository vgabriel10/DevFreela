using DevFreela.Application.Commands.ProjectCommands.InsertProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;
using Moq;

namespace DevFreela.UnitTests.Application.Commands
{
    
    public class CreateProjectCommandHandlerTest
    {
        [Fact]
        public async Task InputDataIsOK_Executed_ReturnProjectId()
        {
            // Arrange
            var projectRepositoryMock = new Mock<IProjectRepository>();
            var mediatorMock = new Mock<IMediator>();
            var createdProjectCommand = new InsertProjectCommand
            {
                IdClient = 1,
                IdFreelancer = 2,
                Title = "Sistema de estacionamento",
                Description = "Description",
                TotalCost = 10000
            };

            var createdProjectCommandHandler = new InsertProjectHandler(projectRepositoryMock.Object, mediatorMock.Object);

            // Act
            var id = await createdProjectCommandHandler.Handle(createdProjectCommand,new CancellationToken());

            // Assert
            Assert.True(id.Data >= 0);

            projectRepositoryMock.Verify(pr => pr.Add(It.IsAny<Project>()), Times.Once);
        }
    }
}
