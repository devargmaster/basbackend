
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Entities;

public class Usuarios : BaseDomainEntity
{
    [Required]
    [MaxLength(100)]
    public required string Nombre { get; set; }
    
    [Required]
    [MaxLength(100)]
    public required string Apellido { get; set; }
    
    [Required]
    [MaxLength(50)]
    public required string UserName { get; set; }
    
    [Required]
    [MaxLength(255)]
    public required string Password { get; set; }
    
    [MaxLength(150)]
    public string? Email { get; set; }
    
    [MaxLength(20)]
    public string? Telefono { get; set; }
    
    // Relación con Roles
    public int? RolId { get; set; }
    public Roles? Rol { get; set; }
    
    // Información adicional
    public DateTime? UltimoAcceso { get; set; }
    public int IntentosLoginFallidos { get; set; } = 0;
    public DateTime? FechaBloqueado { get; set; }
    
    // Navegación
    public ICollection<MovimientosInventario> MovimientosInventario { get; set; } = new List<MovimientosInventario>();
    
    // Propiedad calculada para nombre completo
    public string NombreCompleto => $"{Nombre} {Apellido}";
}
