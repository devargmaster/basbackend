using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CoreWebApi.Models.Entities;
namespace CoreWebApi.ApiData.EntityConfigurations;

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