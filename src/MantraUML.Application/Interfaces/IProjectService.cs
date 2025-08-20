using MantraUML.Application.Dtos;

namespace MantraUML.Application.Interfaces;

public interface IProjectService
{
    Task<IEnumerable<ProjectResponse>> FindAllAsyncByUserId(string userId);
}
