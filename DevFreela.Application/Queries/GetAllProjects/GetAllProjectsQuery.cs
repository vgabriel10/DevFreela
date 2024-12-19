using DevFreela.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQuery : IRequest<ResultViewModel<List<ProjectItemViewModel>>>
    {

        public GetAllProjectsQuery(string search, int page, int size)
        {
            Search = search;
            Page = page;
            Size = size;
        }

        public string Search { get; set; } = string.Empty;
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 20;
    }
}
