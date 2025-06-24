using Domain.Models.Entities;
using Humanizer;
using Infraestructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Contexts;

public class AppDbContext : DbContext, IDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbContext GetContext()
    {
        return this;
    }

    // public DbSet<Permissions> Permissions { get; set; }
    // public DbSet<PermissionsType> PermissionsTypes { get; set; }

    public DbSet<Usuarios> Usuarios { get; set; }
    public DbSet<Inventario> Inventarios { get; set; }
    public DbSet<Productos> Productos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Productos>()
       .Property(p => p.Precio)
       .HasPrecision(18, 2); 
        
        base.OnModelCreating(modelBuilder);
        
    }
}