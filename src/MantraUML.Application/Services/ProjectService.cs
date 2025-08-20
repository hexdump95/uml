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

    public async Task<IEnumerable<ProjectResponse>> FindAllAsyncByUserId(string userId)
    {
        var projects = _projectRepository.FindAllAsyncByUserId(userId);
        List<ProjectResponse> response = _mapper.Map<List<Project>, List<ProjectResponse>>((await projects).ToList());
        return response;
    }
}
