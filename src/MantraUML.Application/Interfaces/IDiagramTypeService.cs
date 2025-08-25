using MantraUML.Application.Dtos;

namespace MantraUML.Application.Interfaces;

public interface IDiagramTypeService
{
    Task<List<DiagramTypeResponse>> GetAllAsync();
}
