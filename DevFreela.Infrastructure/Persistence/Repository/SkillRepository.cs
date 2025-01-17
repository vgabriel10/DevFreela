using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {

        public SkillRepository()
        {
            
        }

        public async Task<List<Skill>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

            
        
    }
}
