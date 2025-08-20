using AutoMapper;

using MantraUML.Application.Dtos;
using MantraUML.Application.Interfaces;
using MantraUML.Domain.Entities;
using MantraUML.Domain.Interfaces;

namespace MantraUML.Application.Services;

public class DiagramService : IDiagramService
{
    private readonly IDiagramRepository _diagramRepository;
    private readonly IMapper _mapper;

    public DiagramService(IDiagramRepository diagramRepository, IMapper mapper)
    {
        _diagramRepository = diagramRepository;
        _mapper = mapper;
    }

    public async Task<List<DiagramResponse>> FindAllAsyncByProjectIdAndUserId(Guid projectId, string userId)
    {
        var diagrams = await _diagramRepository.FindAllAsyncByProjectIdAndUserId(projectId, userId);
        return _mapper.Map<List<Diagram>, List<DiagramResponse>>(diagrams.ToList());
    }
}
