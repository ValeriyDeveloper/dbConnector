using Microsoft.EntityFrameworkCore;
using src.Entities;

namespace src.Data;

public class ApplicationDbContext : DbContext
{
    private const string TrainingSchema = "training";
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>().ToTable("Client", TrainingSchema);
        modelBuilder.Entity<Client>().Property(p => p.CreatedAt).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
        modelBuilder.Entity<Client>().Property(p => p.UpdatedAt).HasDefaultValueSql("NOW()")
            .ValueGeneratedOnAddOrUpdate();
    }
}