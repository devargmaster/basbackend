using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models.Entities;
namespace Infraestructure.ApiData.EntityConfigurations;

public class UsuariosConfigurations: IEntityTypeConfiguration<Usuarios>
{
    public void Configure(EntityTypeBuilder<Usuarios> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nombre).IsRequired();
        // builder.Property(x => x.ApellidoEmpleado).IsRequired();
        // builder.Property(x => x.PermissionsTypeId).IsRequired();
    }
}