
using DevFreela.Application.Commands.SkillCommands.CreateSkill;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;

namespace DevFreela.UnitTests.Application.Commands.SkillCommands
{
    public class CreateSkillCommandHandlerTest
    {
        [Fact]
        public async Task Given_ValidSkill_When_CreatingSkill_Then_ShouldBeCreatedSuccessfully()
        {
            // Arrange
            var skill = new Skill("C#");

            var skillRepositoryMock = new Mock<ISkillRepository>();
            // Configurando o Mock para retornar 1 ao chamar AddAsync com qualquer Skill
            // Usei o It.IsAny pois no Handler ele cria uma nova instancia de skill no .ToEntity()
            skillRepositoryMock.Setup(s => s.AddAsync(It.IsAny<Skill>())).ReturnsAsync(1);

            var createSkillCommand = new CreateSkillCommand
            {
                Description = "C#"
            };
            var createSkillCommandHandler = new CreateSkillHandler(skillRepositoryMock.Object);

            // Act
            var result = await createSkillCommandHandler.Handle(createSkillCommand, new CancellationToken());

            // Assert

            Assert.NotNull(result.Data);
            Assert.True(result.Data >= 1);

            skillRepositoryMock.Verify(s => s.AddAsync(It.IsAny<Skill>()), Times.Once);
        }
    }
}
