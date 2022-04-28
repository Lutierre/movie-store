namespace MovieStore.Abstractions;

public interface IService<T>
{
    T Create(T entity);
    
    IEnumerable<T> Get();

    T? Get(Guid id);

    T? Update(Guid id, T entity);

    void Delete(Guid id);
}
