
using DevFreela.Application.Queries.SkillQueries.GetAllSkills;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;

namespace DevFreela.UnitTests.Application.Queries.SkillQueries
{
    public class GetAllSkillsQueryHandlerTest
    {
        [Fact]
        public async Task ThreeSkillsExist_Executed_ReturnThreeSkillViewModel()
        {
            // Arrange
            var skills = new List<Skill>
            {
                new Skill("teste 1"),
                new Skill("teste 2"),
                new Skill("teste 3"),
            };

            var skillRepositoryMock = new Mock<ISkillRepository>();

            skillRepositoryMock.Setup(s => s.GetAllAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(skills);

            var getAllSkillQuery = new GetAllSkillQuery();
            var getAllSkillQueryHandler = new GetAllSkillHandler(skillRepositoryMock.Object);

            // Act

            var skillViewModel = await getAllSkillQueryHandler.Handle(getAllSkillQuery,new CancellationToken());

            // Assert

            Assert.NotNull(skillViewModel);
            Assert.NotEmpty(skillViewModel.Data);


            skillRepositoryMock
                .Verify(s => s.GetAllAsync(It.IsAny<int>(), It.IsAny<int>()).Result, Times.Once);

        }
    }
}
