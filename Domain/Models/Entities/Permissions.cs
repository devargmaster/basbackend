
namespace Domain.Models.Entities;

public class Permissions : BaseDomainEntity
{
    public required string NombreEmpleado { get; set; }
    public required string ApellidoEmpleado { get; set; }
    
    public DateTime FechaPermiso { get; set; }
    
    public int PermissionsTypeId { get; set; }
}