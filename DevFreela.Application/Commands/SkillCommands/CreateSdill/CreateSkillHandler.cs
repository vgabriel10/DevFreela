
using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.SkillCommands.CreateSdill
{
    public class CreateSkillHandler : IRequestHandler<CreateSkillCommand, ResultViewModel>
    {
        public async Task<ResultViewModel> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
