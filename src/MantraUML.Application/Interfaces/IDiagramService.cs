using MantraUML.Application.Dtos;

namespace MantraUML.Application.Interfaces;

public interface IDiagramService
{
    Task<DiagramDetailResponse> FindOneByIdAndUserId(Guid diagramId, string userId);
    Task<DiagramResponse> CreateDiagramByProjectId(Guid projectId, string userId, DiagramRequest request);
}
