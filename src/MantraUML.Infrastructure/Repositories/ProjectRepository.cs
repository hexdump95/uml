using MantraUML.Domain.Entities;
using MantraUML.Domain.Interfaces;
using MantraUML.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace MantraUML.Infrastructure.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly ApplicationDbContext _context;

    public ProjectRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Project>> FindAllAsync()
    {
        return await _context.Projects
            .ToListAsync();
    }
}
