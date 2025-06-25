using System;

namespace Domain.Models.Entities;

public class Productos : BaseDomainEntity
{
    public required string Nombre { get; set; }
    public required string Descripcion { get; set; }
    public required decimal Precio { get; set; }
    public int Stock { get; set; } = 0;
    public bool Activo { get; set; } = true; // Por defecto, el producto está activo
    public DateTime Creado { get; set; } = DateTime.UtcNow;
    public DateTime? Modificado { get; set; }
    public DateTime? Eliminado { get; set; }
    public DateTime? FechaUltimoMovimiento { get; set; }

    public int UsuarioId { get; set; }

    public Usuarios? Usuarios { get; set; }
    public string? ImagenUrl { get; set; }
    public int? CategoriaId { get; set; }

    public Categorias? Categoria { get; set; }

    public string? Marca { get; set; }
    public string? CodigoBarras { get; set; }
    public string? UnidadMedida { get; set; }
    public DateTime? FechaVencimiento { get; set; }
    public string? Proveedor { get; set; }
    public string? Observaciones { get; set; }
    public int? CantidadMinima { get; set; }
    public int? CantidadMaxima { get; set; }
    public DateTime? FechaUltimoReabastecimiento { get; set; } 
    public ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();
}
