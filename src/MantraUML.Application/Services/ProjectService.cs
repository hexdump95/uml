using AutoMapper;

using MantraUML.Application.Dtos;
using MantraUML.Application.Interfaces;
using MantraUML.Domain.Entities;
using MantraUML.Domain.Interfaces;

namespace MantraUML.Application.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;

    public ProjectService(IProjectRepository projectRepository, IMapper mapper)
    {
        _projectRepository = projectRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProjectResponse>> FindAllByUserId(string userId)
    {
        var projects = _projectRepository.FindAllByUserIdAsync(userId);
        List<ProjectResponse> response = _mapper.Map<List<Project>, List<ProjectResponse>>((await projects).ToList());
        return response;
    }

    public async Task<ProjectResponse> FindOneByIdAndUserId(Guid id, string userId)
    {
        var project = await _projectRepository.FindOneByIdAsync(id);
        if (project != null && project.UserId == userId)
        {
            return _mapper.Map<Project, ProjectResponse>(project);
        }

        return new ProjectResponse();
    }

    public async Task<ProjectResponse> UpdateProjectNameByIdAndUserId(Guid id, string userId, ProjectRequest request)
    {
        var project = await _projectRepository.FindOneByIdAsync(id);
        if (project != null && project.UserId == userId)
        {
            project.Name = request.Name;
            await _projectRepository.SaveChangesAsync();
            return _mapper.Map<Project, ProjectResponse>(project);
        }

        return new ProjectResponse();
    }

    public async Task<ProjectWithDiagramsResponse> FindOneWithDiagramsByIdAndUserId(Guid id, string userId)
    {
        var project = await _projectRepository.FindOneByIdWithDiagramsAsync(id);
        if (project != null && project.UserId == userId)
        {
            return _mapper.Map<Project, ProjectWithDiagramsResponse>(project);
        }

        return new ProjectWithDiagramsResponse();
    }

    public async Task<ProjectResponse> CreateProject(ProjectRequest request, string userId)
    {
        var project = _mapper.Map<ProjectRequest, Project>(request);
        project.UserId = userId;
        project.CreatedAt = DateTime.UtcNow;
        project.UpdatedAt = project.CreatedAt;
        project = await _projectRepository.SaveAsync(project);
        return _mapper.Map<Project, ProjectResponse>(project);
    }
}
