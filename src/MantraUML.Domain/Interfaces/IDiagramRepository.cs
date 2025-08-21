using MantraUML.Domain.Entities;

namespace MantraUML.Domain.Interfaces;

public interface IDiagramRepository : IRepository<Diagram, Guid>
{
    Task<IEnumerable<Diagram>> FindAllAsyncByProjectIdAndUserId(Guid projectId, string userId);
    Task<Diagram?> FindOneAsyncByIdAndUserId(Guid diagramId,string userId);
}
