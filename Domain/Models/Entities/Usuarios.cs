
namespace Domain.Models.Entities;

public class Usuarios : BaseDomainEntity
{
    public required string Nombre { get; set; }
    public required string Apellido { get; set; } 
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public string? Email { get; set; }
    public bool Activo { get; set; }
    public DateTime Creado { get; set; } = DateTime.UtcNow; 
}
