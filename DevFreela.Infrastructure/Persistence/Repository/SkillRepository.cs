using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;


namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DevFreelaDbContext _context;

        public SkillRepository(DevFreelaDbContext context)
        {

            _context = context;
        }

        public async Task<int> AddAsync(Skill skill)
        {
            await _context.AddAsync(skill);
            await _context.SaveChangesAsync();
            return skill.Id;
        }

        public async Task<List<Skill>> GetAllAsync()
        {
            return await _context.Skills.ToListAsync();
        }

            
        
    }
}
