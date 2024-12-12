using DevFreela.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Application.Models;

namespace DevFreela.API.Controllers
{
    [Route("api/skills")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly DevFreelaDbContext _context;
        public SkillsController(DevFreelaDbContext context)
        {
            _context = context;
        }
        // GET api/skills
        [HttpGet]
        public IActionResult GetAll()
        {
            var skills = _context.Skills.ToList();
            return Ok(skills);
        }

        // POST api/skills
        [HttpPost]
        public IActionResult Post(CreateSkillInputModel model)
        {
            var skill = new Skill(model.Description);
            _context.Skills.Add(skill);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
