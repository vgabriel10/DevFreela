
using DevFreela.Application.Queries.UserQuerties.GetUserById;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;

namespace DevFreela.UnitTests.Application.Queries.UserQueries
{
    public class GetUserByIdQueryHandlerTest
    {
        [Fact]
        public async Task UserExists_ById_Executed_ReturnsUserViewModel()
        {
            // ARRANGE
            var usuario = new User("User 1", "userteste@email.com", new DateTime(2000,12,01) ,"123","client");
            var userRepositoryMock = new Mock<IUserRepository>();

            userRepositoryMock
           .Setup(u => u.GetByIdAsync(1))
           .ReturnsAsync(usuario);

            var getByIdUserQuery = new GetUserByIdQuery(1);
            var getByIdUserQueryHanlder = new GetUserByIdHandler(userRepositoryMock.Object);

            // ACT
            var userViewModel = await getByIdUserQueryHanlder.Handle(getByIdUserQuery, new CancellationToken());

            // ASSERT
            Assert.NotNull(userViewModel);
            Assert.Equal(usuario.FullName, userViewModel.Data.FullName);
            Assert.Equal(usuario.Email, userViewModel.Data.Email);

            // Verifica se o método foi chamado exatamente uma vez
            userRepositoryMock.Verify(u => u.GetByIdAsync(1), Times.Once);
        }
    }
}
