using Domain.Models.Entities;
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
    
    // DbSets
    public DbSet<Usuarios> Usuarios { get; set; }
    public DbSet<Roles> Roles { get; set; }
    public DbSet<Productos> Productos { get; set; }
    public DbSet<Categorias> Categorias { get; set; }
    public DbSet<Stock> Stock { get; set; }
    public DbSet<MovimientosInventario> MovimientosInventario { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuración de Usuarios
        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.UserName).IsUnique();
            entity.HasIndex(e => e.Email).IsUnique();
            
            entity.HasOne(u => u.Rol)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(u => u.RolId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // Configuración de Roles
        modelBuilder.Entity<Roles>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Nombre).IsUnique();
        });

        // Configuración de Productos
        modelBuilder.Entity<Productos>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(p => p.Precio).HasPrecision(18, 2);
            entity.Property(p => p.PrecioCompra).HasPrecision(18, 2);
            entity.Property(p => p.PrecioMayoreo).HasPrecision(18, 2);
            entity.Property(p => p.IVA).HasPrecision(5, 4);
            entity.Property(p => p.Peso).HasPrecision(10, 3);
            entity.Property(p => p.Largo).HasPrecision(10, 2);
            entity.Property(p => p.Ancho).HasPrecision(10, 2);
            entity.Property(p => p.Alto).HasPrecision(10, 2);
            
            entity.HasIndex(e => e.CodigoBarras).IsUnique();
            
            entity.HasOne(p => p.Categoria)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // Configuración de Categorías
        modelBuilder.Entity<Categorias>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Nombre).IsUnique();
            entity.HasIndex(e => e.Codigo).IsUnique();
        });

        // Configuración de Stock
        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(s => s.CostoUnitarioPromedio).HasPrecision(18, 2);
            
            entity.HasIndex(e => e.ProductoId).IsUnique(); // Relación uno a uno
            
            entity.HasOne(s => s.Producto)
                .WithOne(p => p.Stock)
                .HasForeignKey<Stock>(s => s.ProductoId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Configuración de MovimientosInventario
        modelBuilder.Entity<MovimientosInventario>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(m => m.Costo).HasPrecision(18, 2);
            entity.Property(m => m.MontoTotal).HasPrecision(18, 2);
            
            entity.HasOne(m => m.Producto)
                .WithMany(p => p.MovimientosInventario)
                .HasForeignKey(m => m.ProductoId)
                .OnDelete(DeleteBehavior.Restrict);
                
            entity.HasOne(m => m.Usuario)
                .WithMany(u => u.MovimientosInventario)
                .HasForeignKey(m => m.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        base.OnModelCreating(modelBuilder);
        
        // Aplicar datos semilla
        Infraestructure.Data.DataSeeder.SeedData(modelBuilder);
    }
}