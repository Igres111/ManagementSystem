﻿using ManagmentSystemApi.Data;
using ManagmentSystemApi.Dtos;
using ManagmentSystemApi.Models;
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
        public ProjectController(Context context)
        {
            _context = context;
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
            var instance = new Project
            {
                Id = Guid.NewGuid(),
                Name = project.Name,
                Description = project.Description,
                WorkerCount = project.WorkerCount,
                Difficulty = project.Difficulty,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(7),
                Status = "In Progress"
            };
            await _context.Projects.AddAsync(instance);
            await _context.SaveChangesAsync();
            return Ok("Project Created");
        }
        [HttpDelete("Delete-Project/{id}")]
        public async Task<IActionResult> DeleteProject(Guid id)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
                return Ok("Delete is Successful");
            }
            return NotFound("Project Not Found");
        }
    }
}
