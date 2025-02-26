using DevFreela.Application.Queries.ProjectQueries.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;

namespace DevFreela.UnitTests.Application.Queries.ProjectQueries
{
    public class GetAllProjectsQueryHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExist_Executed_ReturnThreeProjectViewModel()
        {
            // Arrange
            var projects = new List<Project>
            {
                new Project("Teste 1", "Descrição", 1,2, 10000),
                new Project("Teste 2", "Descrição", 1,4, 20000),
                new Project("Teste 3", "Descrição", 5,2, 30000),
            };

            var projectRepositoryMock = new Mock<IProjectRepository>();

            //Exemplo passando os valores opcionais manualmente
            //projectRepository.Setup(pr => pr.GetAll("",0,0).Result).Returns(projects);

            //Exemplo passando os valores opcionais com o It.IsAny<Tipo>
            projectRepositoryMock
            .Setup(pr => pr.GetAll(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
            .ReturnsAsync(projects);

            var getAllProjectsQuery = new GetAllProjectsQuery("", 0, 0);
            var getAllProjectsQueryHandler = new GetAllProjectsHandler(projectRepositoryMock.Object);

            // Act
            var projectViewModelList = await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

            // Assert
            Assert.NotNull(projectViewModelList);
            Assert.NotEmpty(projectViewModelList.Data);
            Assert.Equal(projects.Count, projectViewModelList?.Data?.Count);

            projectRepositoryMock
                .Verify(pr => pr.GetAll("", 0, 0).Result, Times.Once);
        }
    }
}
