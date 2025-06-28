using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models.Entities;

namespace Infraestructure.ApiData.EntityConfigurations;

public class RolesConfigurations : IEntityTypeConfiguration<Roles>
{
    public void Configure(EntityTypeBuilder<Roles> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nombre).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Descripcion).HasMaxLength(200);
        
        // Datos semilla para roles
        builder.HasData(
            new Roles
            {
                Id = 1,
                Nombre = "Administrador",
                Descripcion = "Administrador del sistema con todos los permisos",
                EsAdministrador = true,
                PuedeGestionarUsuarios = true,
                PuedeGestionarProductos = true,
                PuedeGestionarInventario = true,
                PuedeVerReportes = true,
                Activo = true,
                FechaCreacion = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Roles
            {
                Id = 2,
                Nombre = "Gerente",
                Descripcion = "Gerente con permisos de gestión de productos e inventario",
                EsAdministrador = false,
                PuedeGestionarUsuarios = false,
                PuedeGestionarProductos = true,
                PuedeGestionarInventario = true,
                PuedeVerReportes = true,
                Activo = true,
                FechaCreacion = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Roles
            {
                Id = 3,
                Nombre = "Empleado",
                Descripcion = "Empleado con permisos básicos",
                EsAdministrador = false,
                PuedeGestionarUsuarios = false,
                PuedeGestionarProductos = true,
                PuedeGestionarInventario = false,
                PuedeVerReportes = false,
                Activo = true,
                FechaCreacion = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            }
        );
    }
}
