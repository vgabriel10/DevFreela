using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface ISkillRepository
    {
        Task<List<Skill>> GetAllAsync(int page, int size); 
        Task<int> AddAsync(Skill skill);
    }
}
