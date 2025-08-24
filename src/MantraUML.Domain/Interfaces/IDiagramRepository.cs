using MantraUML.Domain.Entities;

namespace MantraUML.Domain.Interfaces;

public interface IDiagramRepository : IRepository<Diagram, Guid>
{
    Task<Diagram?> FindOneByIdAndUserIdAsync(Guid diagramId,string userId);
}
