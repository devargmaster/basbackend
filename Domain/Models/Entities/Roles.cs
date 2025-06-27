using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Entities;

public class Roles : BaseDomainEntity
{
    [Required]
    [MaxLength(50)]
    public required string Nombre { get; set; }
    
    [MaxLength(200)]
    public string? Descripcion { get; set; }
    
    // Permisos como flags
    public bool PuedeGestionarUsuarios { get; set; } = false;
    public bool PuedeGestionarProductos { get; set; } = false;
    public bool PuedeGestionarInventario { get; set; } = false;
    public bool PuedeVerReportes { get; set; } = false;
    public bool EsAdministrador { get; set; } = false;
    
    // Navegación
    public ICollection<Usuarios> Usuarios { get; set; } = new List<Usuarios>();
}
