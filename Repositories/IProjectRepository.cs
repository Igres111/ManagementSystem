using ManagmentSystemApi.Data;
using ManagmentSystemApi.Dtos;
using ManagmentSystemApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagmentSystemApi.Repositories
{
    public class IProjectRepository : IProject
    {
        public readonly Context _context;
        public IProjectRepository(Context context)
        {
            _context = context;
        }
        public async Task<bool> CreateProject(CreateProjectDto project)
        {
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
            if (_context != null)
            {
                await _context.Projects.AddAsync(instance);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> DeleteProject(Guid id)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateProject(ChangeProjectFull project)
        {
            var instance = await _context.Projects.FirstOrDefaultAsync(p => p.Id == project.Id);
            if (instance != null)
            {
                instance.Name = project.Name;
                instance.Description = project.Description;
                instance.WorkerCount = project.WorkerCount;
                instance.Difficulty = project.Difficulty;
                instance.StartDate = project.StartDate;
                instance.EndDate = project.StartDate.AddDays(7);
                instance.Status = project.Status;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
