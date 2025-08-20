using MantraUML.Domain.Entities;

namespace MantraUML.Domain.Interfaces;

public interface IProjectRepository : IRepository<Project>
{
    Task<IEnumerable<Project>> FindAllAsyncByUserId(string userId);
}
