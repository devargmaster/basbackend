using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Entities;

public class Categorias : BaseDomainEntity
{
    [Required]
    [MaxLength(100)]
    public required string Nombre { get; set; }
    
    [MaxLength(500)]
    public string? Descripcion { get; set; }
    
    [MaxLength(50)]
    public string? Codigo { get; set; }
    
    [MaxLength(7)]
    public string? Color { get; set; } // Para identificación visual (hex color)
    
    [MaxLength(50)]
    public string? Icono { get; set; } // Nombre del icono
    
    public int Orden { get; set; } = 0; // Para ordenamiento
    
    // Navegación
    public ICollection<Productos> Productos { get; set; } = new List<Productos>();
}