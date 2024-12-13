using Microsoft.AspNetCore.Mvc;
using DevFreela.Application.Models;
using DevFreela.Application.Services;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // GET api/projects?search=crm
        [HttpGet]
        public IActionResult Get(string search = "", int page = 0, int size = 3)
        {
            var result = _projectService.GetAll(search,page,size);

            return Ok(result);
        }

        // GET api/projects/1234
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _projectService.GetById(id);

            if (!result.IsSucess)
                return BadRequest(result.Message);

            return Ok(result);
        }

        // POST api/projects
        [HttpPost]
        public IActionResult Post(CreateProjectInputModel model)
        {
            var result = _projectService.Insert(model);

            return CreatedAtAction(nameof(GetById), new {id = result.Data}, model);
        }

        // PUT api/projects/1234
        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateProjectInputModel model)
        {
            var result = _projectService.Update(model);

            if (!result.IsSucess)
                return BadRequest(result.Message);

            return NoContent();
        }

        //  DELETE api/projects/1234
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _projectService.Delete(id);

            if (!result.IsSucess)
                return BadRequest(result.Message);

            return NoContent();
        }

        // PUT api/projects/1234/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            var result = _projectService.Start(id);

            if (!result.IsSucess)
                return BadRequest(result.Message);

            return NoContent();
        }

        // PUT api/projects/1234/complete
        [HttpPut("{id}/complete")]
        public IActionResult Complete(int id)
        {
            var result = _projectService.Complete(id);

            if (!result.IsSucess)
                return BadRequest(result.Message);

            return NoContent();
        }

        // POST api/projects/1234/comments
        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, CreateProjectCommentInputModel model)
        {
            var result = _projectService.InsertComment(id, model);

            if (!result.IsSucess)
                return BadRequest(result.Message);

            return NoContent();
        }
    }
}
