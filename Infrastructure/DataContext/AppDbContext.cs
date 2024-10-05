using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataContext;

public class AppDbContext : DbContext
{
    public DbSet<Book> Books { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BookConfig());
        base.OnModelCreating(modelBuilder);
    }
}