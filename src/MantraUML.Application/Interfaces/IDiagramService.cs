using MantraUML.Application.Dtos;

namespace MantraUML.Application.Interfaces;

public interface IDiagramService
{
    Task<DiagramDetailResponse> FindOneByIdAndUserId(Guid diagramId, string userId);
}
