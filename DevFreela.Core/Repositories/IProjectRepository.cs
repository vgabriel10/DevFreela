using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAll(string search = "", int page = 0, int size = 20);
        Task<Project?> GetById(int id);
        Task<Project?> GetDetailsById(int id);
        Task<int> Add(Project project);
        Task Update(Project project);
        Task AddComment(ProjectComment comment);
        Task<bool> Exist(int id);
    }
}
