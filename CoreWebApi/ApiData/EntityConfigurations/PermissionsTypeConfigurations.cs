using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CoreWebApi.Models.Entities;
namespace CoreWebApi.ApiData.EntityConfigurations;

public class PermissionsTypeConfigurations: IEntityTypeConfiguration<PermissionsType>
{
    public void Configure(EntityTypeBuilder<PermissionsType> builder)
    {
        builder.Property(x => x.Descripcion).IsRequired();
    }
    
}