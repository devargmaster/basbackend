using Infraestructure.Models;

namespace CoreWebApi.Models.Entities;

public class PermissionsType : BaseDomainEntity
{
    public required string Descripcion { get; set; }
}