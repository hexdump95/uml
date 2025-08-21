using MantraUML.Domain.Entities;

namespace MantraUML.Domain.Interfaces;

public interface IProjectRepository : IRepository<Project, Guid>
{
    Task<IEnumerable<Project>> FindAllAsyncByUserId(string userId);
}
