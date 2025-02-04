
using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.UserCommands.InsertUserSkill
{
    public class InsertUserSkillHandler : IRequestHandler<InsertUserSkillCommand, ResultViewModel>
    {
        private readonly DevFreelaDbContext _context;

        public InsertUserSkillHandler(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(InsertUserSkillCommand request, CancellationToken cancellationToken)
        {
            var userSkill = request.ToEntity();
            await _context.AddAsync(userSkill);
            await _context.SaveChangesAsync();

            return ResultViewModel.Sucess();
        }
    }
}
