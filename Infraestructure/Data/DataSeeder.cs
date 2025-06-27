using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data;

public static class DataSeeder
{
    public static void SeedData(ModelBuilder modelBuilder)
    {
        // Seed Roles
        modelBuilder.Entity<Roles>().HasData(
            new Roles
            {
                Id = 1,
                Nombre = "Administrador",
                Descripcion = "Acceso completo al sistema",
                PuedeGestionarUsuarios = true,
                PuedeGestionarProductos = true,
                PuedeGestionarInventario = true,
                PuedeVerReportes = true,
                EsAdministrador = true,
                Activo = true,
                FechaCreacion = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Roles
            {
                Id = 2,
                Nombre = "Gerente",
                Descripcion = "Gestión de productos e inventario",
                PuedeGestionarUsuarios = false,
                PuedeGestionarProductos = true,
                PuedeGestionarInventario = true,
                PuedeVerReportes = true,
                EsAdministrador = false,
                Activo = true,
                FechaCreacion = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Roles
            {
                Id = 3,
                Nombre = "Empleado",
                Descripcion = "Operaciones básicas de inventario",
                PuedeGestionarUsuarios = false,
                PuedeGestionarProductos = false,
                PuedeGestionarInventario = true,
                PuedeVerReportes = false,
                EsAdministrador = false,
                Activo = true,
                FechaCreacion = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            }
        );

        // Seed Categorías
        modelBuilder.Entity<Categorias>().HasData(
            new Categorias
            {
                Id = 1,
                Nombre = "Electrónicos",
                Descripcion = "Dispositivos y componentes electrónicos",
                Codigo = "ELEC",
                Color = "#3B82F6",
                Icono = "💻",
                Orden = 1,
                Activo = true,
                FechaCreacion = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Categorias
            {
                Id = 2,
                Nombre = "Oficina",
                Descripcion = "Materiales y suministros de oficina",
                Codigo = "OFIC",
                Color = "#10B981",
                Icono = "📁",
                Orden = 2,
                Activo = true,
                FechaCreacion = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Categorias
            {
                Id = 3,
                Nombre = "Herramientas",
                Descripcion = "Herramientas y equipos de trabajo",
                Codigo = "HERR",
                Color = "#F59E0B",
                Icono = "🔧",
                Orden = 3,
                Activo = true,
                FechaCreacion = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            }
        );
    }
}
