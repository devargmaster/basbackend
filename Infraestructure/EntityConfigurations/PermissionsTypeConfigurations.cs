using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models.Entities;
namespace Infraestructure.ApiData.EntityConfigurations;

public class PermissionsTypeConfigurations: IEntityTypeConfiguration<PermissionsType>
{
    public void Configure(EntityTypeBuilder<PermissionsType> builder)
    {
        builder.Property(x => x.Descripcion).IsRequired();
    }
    
}