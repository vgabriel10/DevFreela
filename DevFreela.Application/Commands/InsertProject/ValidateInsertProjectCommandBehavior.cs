using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.InsertProject
{
    public class ValidateInsertProjectCommandBehavior : IPipelineBehavior<InsertProjectCommand, ResultViewModel<int>>
    {
        private readonly DevFreelaDbContext _context;

        public ValidateInsertProjectCommandBehavior(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<int>> Handle(InsertProjectCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var clientExist = await _context.Users.AnyAsync(u => u.Id == request.IdClient);
            var freelancerExist = await _context.Users.AnyAsync(u => u.Id == request.IdFreelancer);

            if (!clientExist || !freelancerExist)
            {
                return ResultViewModel<int>.Error("Cliente ou Freelancer inválidos");
            }
            return await next();
        }
    }
}
