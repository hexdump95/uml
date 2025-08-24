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

    public Task<IEnumerable<Project>> FindAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Project> SaveAsync(Project entity)
    {
        await _context.Projects.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Project?> FindOneByIdAsync(Guid id)
    {
        return await _context.FindAsync<Project>(id);
    }

    public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Project?> FindOneByIdWithDiagramsAsync(Guid id)
    {
        return await _context.Projects
            .Include(p => p.Diagrams)
            .ThenInclude(d => d.DiagramType)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Project>> FindAllByUserIdAsync(string userId)
    {
        return await _context.Projects
            .Include(p => p.Diagrams)
            .Where(p => p.UserId == userId)
            .ToListAsync();
    }
}
