
using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.SkillCommands.CreateSkill
{
    public class CreateSkillHandler : IRequestHandler<CreateSkillCommand, ResultViewModel<int>>
    {
        private readonly ISkillRepository _repository;

        public CreateSkillHandler(ISkillRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<int>> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            var skill = request.ToEntity();
            var result = await _repository.AddAsync(skill);

            if (result == 0)
                return ResultViewModel<int>.Error("Erro ao criar uma skill");

            return ResultViewModel<int>.Sucess(result);
        }
    }
}
