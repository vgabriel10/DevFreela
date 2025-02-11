
using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.SkillQueries.GetAllSkills
{
    public class GetAllSkillHandler : IRequestHandler<GetAllSkillQuery, ResultViewModel<List<SkillViewModel>>>
    {
        private readonly ISkillRepository _repository;
        public GetAllSkillHandler(ISkillRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<List<SkillViewModel>>> Handle(GetAllSkillQuery request, CancellationToken cancellationToken)
        {
            var skills = await _repository.GetAllAsync(request.Page,request.Size);
            var skillsViewModel = skills.Select(SkillViewModel.FromEntity).ToList();
            return ResultViewModel<List<SkillViewModel>>.Sucess(skillsViewModel);
        }
    }
}
