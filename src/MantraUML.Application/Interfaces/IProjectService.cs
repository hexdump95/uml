using MantraUML.Application.Dtos;

namespace MantraUML.Application.Interfaces;

public interface IProjectService
{
    Task<IEnumerable<ProjectResponse>> FindAllByUserId(string userId);
    Task<ProjectResponse> FindOneByIdAndUserId(Guid id, string userId);
    Task<ProjectWithDiagramsResponse> FindOneWithDiagramsByIdAndUserId(Guid id, string userId);
    Task<ProjectResponse> CreateProject(ProjectRequest request, string userId);
}
