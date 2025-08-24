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

    public async Task<DiagramDetailResponse> FindOneByIdAndUserId(Guid diagramId, string userId)
    {
        var diagram = await _diagramRepository.FindOneByIdAndUserIdAsync(diagramId, userId);
        return _mapper.Map<Diagram, DiagramDetailResponse>(diagram!);
    }
}
