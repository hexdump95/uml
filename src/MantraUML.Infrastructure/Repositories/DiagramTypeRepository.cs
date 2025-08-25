using MantraUML.Domain.Entities;
using MantraUML.Domain.Interfaces;
using MantraUML.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace MantraUML.Infrastructure.Repositories;

public class DiagramTypeRepository : IDiagramTypeRepository
{
    private readonly ApplicationDbContext _context;

    public DiagramTypeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<DiagramType>> FindAllAsync()
    {
        return await _context.DiagramTypes.ToListAsync();
    }

    public Task<DiagramType?> FindOneByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<DiagramType> SaveAsync(DiagramType entity)
    {
        throw new NotImplementedException();
    }
}
