using MantraUML.Domain.Entities;

namespace MantraUML.Domain.Interfaces;

public interface IDiagramRepository : IRepository<Diagram>
{
    Task<IEnumerable<Diagram>> FindAllAsyncByProjectIdAndUserId(Guid projectId, string userId);
}
