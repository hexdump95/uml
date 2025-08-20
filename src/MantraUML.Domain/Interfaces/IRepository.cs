namespace MantraUML.Domain.Interfaces;

public interface IRepository<T>
{
    Task<IEnumerable<T>> FindAllAsync();
}
