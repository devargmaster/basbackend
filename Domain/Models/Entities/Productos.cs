using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Entities;

public class Productos : BaseDomainEntity
{
    [Required]
    [MaxLength(200)]
    public required string Nombre { get; set; }
    
    [MaxLength(1000)]
    public string? Descripcion { get; set; }
    
    [Required]
    public required decimal Precio { get; set; }
    
    [MaxLength(500)]
    public string? ImagenUrl { get; set; }
    
    // Relación con Categoría
    public int? CategoriaId { get; set; }
    public Categorias? Categoria { get; set; }
    
    // Información del producto
    [MaxLength(100)]
    public string? Marca { get; set; }
    
    [MaxLength(50)]
    public string? CodigoBarras { get; set; }
    
    [MaxLength(20)]
    public string? UnidadMedida { get; set; }
    
    [MaxLength(200)]
    public string? Proveedor { get; set; }
    
    [MaxLength(1000)]
    public string? Observaciones { get; set; }
    
    // Información de empaque y dimensiones
    public decimal? Peso { get; set; }
    public decimal? Largo { get; set; }
    public decimal? Ancho { get; set; }
    public decimal? Alto { get; set; }
    
    // Precios adicionales
    public decimal? PrecioCompra { get; set; }
    public decimal? PrecioMayoreo { get; set; }
    
    // Información fiscal
    [MaxLength(10)]
    public string? CodigoSAT { get; set; }
    public decimal IVA { get; set; } = 0.16m; // 16% por defecto
    
    // Navegación
    public Stock? Stock { get; set; }
    public ICollection<MovimientosInventario> MovimientosInventario { get; set; } = new List<MovimientosInventario>();
}
