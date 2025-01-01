using ManagmentSystemApi.Dtos;

namespace ManagmentSystemApi.Repositories
{
    public interface IProject
    {
        Task<bool> CreateProject(CreateProjectDto project);
        Task<bool> DeleteProject(Guid id);
        Task<bool> UpdateProject(ChangeProjectFull project);
    }
}
