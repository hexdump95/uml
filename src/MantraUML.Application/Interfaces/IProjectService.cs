using MantraUML.Application.Dtos;

namespace MantraUML.Application.Interfaces;

public interface IProjectService
{
    Task<IEnumerable<ProjectResponse>> FindAllAsyncByUserId(string userId);
    Task<ProjectResponse> FindOneAsyncByIdAndUserId(Guid id, string userId);
    Task<ProjectResponse> CreateProject(ProjectRequest request, string userId);
}
