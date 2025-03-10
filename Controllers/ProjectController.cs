﻿using ManagmentSystemApi.Data;
using ManagmentSystemApi.Dtos;
using ManagmentSystemApi.Models;
using ManagmentSystemApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetProjects()
        {
            var result = await _context.Projects.ToListAsync();
            return Ok(result);
        }
        [HttpPost("Add-Project")]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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

        [HttpPut("Update-Project-Status")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeProjectStatus(Guid Id, string status)
        {
            if(await _project.ChangeStatus(Id, status))
            {
                return Ok("Status Changed");
            }
          return BadRequest("Not Found");
        }
        [HttpPost("Connect-User-to-Project")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ConnectUserToProject(ConnectProjectToUserDto project)
        {
            await _context.ProjectForUser.AddAsync(new ProjectForUser
            {
                Id = Guid.NewGuid(),
                ProjectId = project.ProjectId,
                UserId = project.UserId,
            });
            await _context.SaveChangesAsync();
            return Ok("Connected");
        }
        [HttpGet("Get-All-User-Projects")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUserProjects(Guid userId)
        {
            var result = await _project.GetUserProjects(userId);

            return Ok(result);
        }
    }
}
