using MantraUML.Domain.Entities;
using MantraUML.Domain.Interfaces;
using MantraUML.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace MantraUML.Infrastructure.Repositories;

public class DiagramRepository : IDiagramRepository
{
    private readonly ApplicationDbContext _context;

    public DiagramRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<IEnumerable<Diagram>> FindAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Diagram?> FindOneByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Diagram> SaveAsync(Diagram entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Diagram>> FindAllAsyncByProjectIdAndUserId(Guid projectId, string userId)
    {
        return await _context.Diagrams
            .Include(d => d.Project)
            .Include(d => d.DiagramType)
            .Where(d => d.ProjectId == projectId
                        && d.Project!.UserId == userId
            )
            .ToListAsync();
    }

    public async Task<Diagram?> FindOneAsyncByIdAndUserId(Guid diagramId, string userId)
    {
        return await _context.Diagrams
            .Include(d => d.Project)
            .Include(d => d.DiagramType)
            .Include(d => d.Elements)
            .Where(d => d.Id == diagramId && d.Project!.UserId == userId)
            .FirstOrDefaultAsync();
    }
}
