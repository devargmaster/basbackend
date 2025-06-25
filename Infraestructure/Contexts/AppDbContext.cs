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
    public DbSet<Usuarios> Usuarios { get; set; }
    public DbSet<Inventario> Inventarios { get; set; }
    public DbSet<Productos> Productos { get; set; }
    public DbSet<Categorias> Categorias { get; set; }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Productos>()
        .Property(p => p.Precio)
        .HasPrecision(18, 2);

    // modelBuilder.Entity<Productos>()
    //     .HasOne(p => p.Usuarios)
    //     .WithMany(u => u.Productos)
    //     .HasForeignKey(p => p.UsuarioId)
    //     .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<Productos>()
        .HasOne(p => p.Categoria)
        .WithMany(c => c.Productos)
        .HasForeignKey(p => p.CategoriaId);

    modelBuilder.Entity<Inventario>()
        .HasOne(i => i.Producto)
        .WithMany(p => p.Inventarios)
        .HasForeignKey(i => i.ProductoId);

    // modelBuilder.Entity<Inventario>()
    //     .HasOne(i => i.Usuario)
    //     .WithMany(u => u.Inventarios)
    //     .HasForeignKey(i => i.UsuarioId);

    base.OnModelCreating(modelBuilder);
}
}