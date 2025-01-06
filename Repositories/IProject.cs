using ManagmentSystemApi.Dtos;
using ManagmentSystemApi.Models;

namespace ManagmentSystemApi.Repositories
{
    public interface IProject
    {
        Task<bool> CreateProject(CreateProjectDto project);
        Task<bool> DeleteProject(Guid id);
        Task<bool> UpdateProject(ChangeProjectFull project);
        Task<bool> ChangeStatus(Guid id, string status);
        Task<List<Project>> GetUserProjects(Guid userId);
    }
}
