using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Entities;

public enum TipoMovimiento
{
    Entrada = 1,
    Salida = 2,
    Ajuste = 3,
    Transferencia = 4,
    Devolucion = 5
}

public class MovimientosInventario : BaseDomainEntity
{
    // Relación con Producto
    public int ProductoId { get; set; }
    public Productos? Producto { get; set; }
    
    // Relación con Usuario que registra el movimiento
    public int UsuarioId { get; set; }
    public Usuarios? Usuario { get; set; }
    
    // Detalles del movimiento
    public TipoMovimiento TipoMovimiento { get; set; }
    public int Cantidad { get; set; }
    public int StockAnterior { get; set; }
    public int StockActual { get; set; }
    
    [MaxLength(500)]
    public string? Observaciones { get; set; }
    
    [MaxLength(100)]
    public string? DocumentoReferencia { get; set; }
    
    // Información adicional según el tipo de movimiento
    [MaxLength(200)]
    public string? Proveedor { get; set; }  // Para entradas
    
    [MaxLength(200)]
    public string? Cliente { get; set; }    // Para salidas
    
    public decimal? Costo { get; set; }     // Costo unitario del movimiento
    public decimal? MontoTotal { get; set; } // Monto total del movimiento
}
