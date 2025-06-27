using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Entities;

public class Stock : BaseDomainEntity
{
    // Relación con Producto (uno a uno)
    public int ProductoId { get; set; }
    public Productos? Producto { get; set; }
    
    // Stock actual
    public int CantidadActual { get; set; } = 0;
    public int CantidadReservada { get; set; } = 0;
    public int CantidadDisponible => CantidadActual - CantidadReservada;
    
    // Límites de stock
    public int StockMinimo { get; set; } = 0;
    public int StockMaximo { get; set; } = 1000;
    
    // Ubicación física
    [MaxLength(50)]
    public string? Ubicacion { get; set; }
    
    [MaxLength(20)]
    public string? Lote { get; set; }
    
    public DateTime? FechaVencimiento { get; set; }
    
    // Información de costos
    public decimal CostoUnitarioPromedio { get; set; } = 0;
    public decimal ValorTotalStock => CantidadActual * CostoUnitarioPromedio;
    
    // Fechas importantes
    public DateTime? FechaUltimoMovimiento { get; set; }
    public DateTime? FechaUltimoReconteo { get; set; }
    
    // Alertas
    public bool RequiereReconteo { get; set; } = false;
    public bool StockBajo => CantidadActual <= StockMinimo;
    public bool StockAlto => CantidadActual >= StockMaximo;
}
