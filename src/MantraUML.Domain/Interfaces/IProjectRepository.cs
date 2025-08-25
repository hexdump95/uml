using MantraUML.Domain.Entities;

namespace MantraUML.Domain.Interfaces;

public interface IProjectRepository : IRepository<Project, Guid>
{
    Task<Project?> FindOneByIdWithDiagramsAsync(Guid id);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<Project>> FindAllByUserIdAsync(string userId);
    Task<bool> ValidateProject(Guid id, string userId);
}
