using Microsoft.EntityFrameworkCore;

namespace src.Data;

public class AutoMigrator
{
    private readonly ApplicationDbContext _context;

    public AutoMigrator(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Run()
    {
        await _context.Database.MigrateAsync();
    }
}