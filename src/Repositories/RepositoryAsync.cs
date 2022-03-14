using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Entities;
using src.Interfaces;

namespace src.Repositories;

public class RepositoryAsync<T> : IRepositoryAsync<T> where T : BaseEntity
{
    private readonly ApplicationDbContext _context;

    public RepositoryAsync(ApplicationDbContext context)
    {
        _context = context;
    }

    public virtual async Task<T?> GetAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public virtual async Task<List<T>> GetListAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public virtual async Task<int> AddAsync(T entity)
    {
        var id = (await _context.Set<T>().AddAsync(entity)).Entity.Id;
        await _context.SaveChangesAsync();
        return id;
    }

    public virtual async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}