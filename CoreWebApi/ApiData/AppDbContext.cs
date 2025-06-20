using CoreWebApi.Models.Entities;
using Infraestructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApi.ApiData;

public class AppDbContext : DbContext, IDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
    {
    }
    public DbContext GetContext()
    {
        return this;
    }

    public DbSet<Permissions> Permissions { get; set; }
    public DbSet<PermissionsType> PermissionsTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Permissions>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<PermissionsType>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });
    }
}