

using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Queries.SkillQueries.GetAllSkills
{
    public class GetAllSkillQuery : IRequest<ResultViewModel<List<SkillViewModel>>>
    {
        public GetAllSkillQuery(int page = 0, int size = 20)
        {
            Page = page;
            Size = size;
        }

        public int Page { get; set; } = 0;
        public int Size { get; set; } = 20;
    }
}
