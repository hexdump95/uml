using MantraUML.Domain.Entities;

namespace MantraUML.Application.Interfaces;

public interface IProjectService
{
    Task<IEnumerable<Project>> FindAllAsyncByUserId(string userId);
}
