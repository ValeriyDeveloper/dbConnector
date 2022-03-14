using src.Entities;

namespace src.Interfaces;

public interface IRepositoryAsync<T> where T : BaseEntity
{
    public Task<T?> GetAsync(int id);
    public Task<List<T>> GetListAsync();
    public Task<int> AddAsync(T entity);
    public Task UpdateAsync(T entity);
    public Task DeleteAsync(T entity);
}