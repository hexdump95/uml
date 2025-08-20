using MantraUML.Application.Dtos;

namespace MantraUML.Application.Interfaces;

public interface IDiagramService
{
    Task<List<DiagramResponse>> FindAllAsyncByProjectIdAndUserId(Guid projectId, string userId);
}
