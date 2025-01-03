using ManagmentSystemApi.Data;
using ManagmentSystemApi.Dtos;
using ManagmentSystemApi.Models;
using ManagmentSystemApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManagmentSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        public readonly Context _context;
        public readonly IProject _project;
        public ProjectController(Context context, IProject project)
        {
            _context = context;
            _project = project;
        }
        [HttpGet("Get-Projects")]
        public async Task<IActionResult> GetProjects()
        {
            var result = await _context.Projects.ToListAsync();
            return Ok(result);
        }
        [HttpPost("Add-Project")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateProject(CreateProjectDto project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _project.CreateProject(project))
            {
                return Ok("Success");
            }
          return BadRequest("Failed");
        }
        [HttpDelete("Delete-Project/{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProject(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(await _project.DeleteProject(id))
            {
            return Ok("Project Deleted");
            }
            return BadRequest("Project Deleted");
        }
        [HttpPut("Update-Project")]
        public async Task<IActionResult> ChangeProjectFully(ChangeProjectFull changedProject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(await _project.UpdateProject(changedProject))
            {
                return Ok("Project Updated");
            }
          
            return BadRequest("Project Updated");
        }
        
        //[HttpPatch("Update-Project-Status")]
        //public async Task<IActionResult> ChangeProjectStatus(ChangeProjectStatusDto project)
        //{
        //}
    }
}
