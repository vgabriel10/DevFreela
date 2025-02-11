using DevFreela.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Application.Models;
using MediatR;
using DevFreela.Application.Commands.SkillCommands.CreateSkill;
using DevFreela.Application.Queries.SkillQueries.GetAllSkills;

namespace DevFreela.API.Controllers
{
    [Route("api/skills")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly DevFreelaDbContext _context;
        private readonly IMediator _mediator;

        public SkillsController(DevFreelaDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        // GET api/skills
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 0, [FromQuery] int size = 20)
        {
            var query = new GetAllSkillQuery(page,size);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // POST api/skills
        [HttpPost]
        public async Task<IActionResult> Post(CreateSkillCommand command)
        {
            var result = await _mediator.Send(command);
            return NoContent();
        }
    }
}
