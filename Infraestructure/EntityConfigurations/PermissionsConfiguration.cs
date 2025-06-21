using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models.Entities;
namespace Infraestructure.ApiData.EntityConfigurations;

public class PermissionsConfiguration: IEntityTypeConfiguration<Permissions>
{
    public void Configure(EntityTypeBuilder<Permissions> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.NombreEmpleado).IsRequired();
        builder.Property(x => x.ApellidoEmpleado).IsRequired();
        builder.Property(x => x.PermissionsTypeId).IsRequired();
    }
}