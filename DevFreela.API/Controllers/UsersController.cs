using DevFreela.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Application.Models;
using DevFreela.Application.Commands.UserCommands.CreateUser;
using MediatR;
using DevFreela.Application.Commands.UserCommands.LoginUser;
using Microsoft.AspNetCore.Authorization;
using DevFreela.Application.Queries.UserQuerties.GetUserById;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly DevFreelaDbContext _context;
        private readonly IMediator _mediator;

        public UsersController(DevFreelaDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id));
            if(user is null)
                return NotFound();

            return Ok(user);
        }

        // POST api/users
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPost("{id}/skills")]
        public IActionResult PostSkills(int id,UserSkillsInputModel model)
        {
            var userSkills = model.SkillIds.Select(s => new UserSkill(id, s)).ToList();
            _context.AddRange(userSkills);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}/profile-picture")]
        public IActionResult PostProfilePicture(int id,IFormFile file)
        {
            var description = $"FIle: {file.FileName}, Size: {file.Length}";

            // Processar a imagem

            return Ok(description);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var loginUserViewModel = await _mediator.Send(command);

            if (loginUserViewModel is null) 
                return BadRequest();

            return Ok(loginUserViewModel);
        }
    }
}
