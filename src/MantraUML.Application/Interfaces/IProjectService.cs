using MantraUML.Domain.Entities;

namespace MantraUML.Application.Interfaces;

public interface IProjectService
{
    Task<IEnumerable<Project>> FindAllAsync();
}
