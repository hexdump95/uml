using AutoMapper;

using MantraUML.Application.Dtos;
using MantraUML.Application.Interfaces;
using MantraUML.Domain.Entities;
using MantraUML.Domain.Interfaces;

namespace MantraUML.Application.Services;

public class DiagramTypeService : IDiagramTypeService
{
    private readonly IDiagramTypeRepository _diagramTypeRepository;
    private readonly IMapper _mapper;

    public DiagramTypeService(IDiagramTypeRepository diagramTypeRepository, IMapper mapper)
    {
        _diagramTypeRepository = diagramTypeRepository;
        _mapper = mapper;
    }

    public async Task<List<DiagramTypeResponse>> GetAllAsync()
    {
        var diagrams = await _diagramTypeRepository.FindAllAsync();
        return _mapper.Map<List<DiagramType>, List<DiagramTypeResponse>>(diagrams.ToList());
    }
}
