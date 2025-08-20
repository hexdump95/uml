using AutoMapper;

using MantraUML.Application.Interfaces;
using MantraUML.Domain.Entities;
using MantraUML.Domain.Interfaces;

namespace MantraUML.Application.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectService(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<IEnumerable<Project>> FindAllAsync()
    {
        return await _projectRepository.FindAllAsync();
    }
}
