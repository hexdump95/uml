namespace MantraUML.Domain.Interfaces;

public interface IRepository<T, in TK>
{
    Task<IEnumerable<T>> FindAllAsync();
    Task<T?> FindOneByIdAsync(TK id);
}
