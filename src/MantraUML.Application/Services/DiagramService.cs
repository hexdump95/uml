using AutoMapper;

using MantraUML.Application.Dtos;
using MantraUML.Application.Interfaces;
using MantraUML.Domain.Entities;
using MantraUML.Domain.Interfaces;

namespace MantraUML.Application.Services;

public class DiagramService : IDiagramService
{
    private readonly IDiagramRepository _diagramRepository;
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;

    public DiagramService(IDiagramRepository diagramRepository, IProjectRepository projectRepository, IMapper mapper)
    {
        _diagramRepository = diagramRepository;
        _projectRepository = projectRepository;
        _mapper = mapper;
    }

    public async Task<DiagramDetailResponse> FindOneByIdAndUserId(Guid diagramId, string userId)
    {
        var diagram = await _diagramRepository.FindOneByIdAndUserIdAsync(diagramId, userId);
        return _mapper.Map<Diagram, DiagramDetailResponse>(diagram!);
    }

    public async Task<DiagramResponse> CreateDiagramByProjectId(Guid projectId, string userId, DiagramRequest request)
    {
        var isProjectValid = await _projectRepository.ValidateProject(projectId, userId);
        if (isProjectValid)
        {
            var diagram = new Diagram
            {
                ProjectId = projectId, DiagramTypeId = request.DiagramTypeId, Name = request.Name,
            };
            diagram = await _diagramRepository.SaveAsync(diagram);
            return _mapper.Map<Diagram, DiagramResponse>(diagram);
        }

        return await Task.FromResult(new DiagramResponse());
    }
}
