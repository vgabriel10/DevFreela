using Azure;
using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectsHandler : IRequestHandler<GetAllProjectsQuery, ResultViewModel<List<ProjectItemViewModel>>>
    {
        private readonly IProjectRepository _repository;

        public GetAllProjectsHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<List<ProjectItemViewModel>>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            //var projects = _context.Projects.
            //    Include(p => p.Client)
            //    .Include(p => p.Freelancer)
            //    .Include(p => p.Comments)
            //    .Where(p => !p.IsDeleted && (request.Search == string.Empty || p.Title.Contains(request.Search) || p.Description.Contains(request.Search)))
            //    .Skip(request.Page * request.Size)
            //    .Take(request.Size)
            //    .ToList();

            var projects = await _repository.GetAll(request.Search,request.Page,request.Size);

            var model = projects.Select(ProjectItemViewModel.FromEntity).ToList();
            return ResultViewModel<List<ProjectItemViewModel>>.Sucess(model);
        }
    }
}
