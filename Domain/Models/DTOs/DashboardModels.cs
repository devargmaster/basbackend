namespace Domain.Models.DTOs;

public class DashboardStatsResponse
{
    public int TotalProductos { get; set; }
    public int TotalUsuarios { get; set; }
    public int TotalCategorias { get; set; }
    public decimal ValorTotalInventario { get; set; }
    public int ProductosStockBajo { get; set; }
    public int ProductosStockAlto { get; set; }
    public int ProductosInactivos { get; set; }
    public int MovimientosHoy { get; set; }
    public int MovimientosSemanales { get; set; }
    public int MovimientosMensuales { get; set; }
    public List<ProductoStockBajo> ProductosConStockBajo { get; set; } = new();
    public List<MovimientoReciente> MovimientosRecientes { get; set; } = new();
    public List<CategoriaStats> TopCategorias { get; set; } = new();
    public List<AlertaInventario> Alertas { get; set; } = new();
}

public class ProductoStockBajo
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int StockActual { get; set; }
    public int StockMinimo { get; set; }
    public string? Categoria { get; set; }
    public decimal? PrecioVenta { get; set; }
}

public class MovimientoReciente
{
    public int Id { get; set; }
    public string Producto { get; set; } = string.Empty;
    public string TipoMovimiento { get; set; } = string.Empty;
    public int Cantidad { get; set; }
    public string Usuario { get; set; } = string.Empty;
    public DateTime Fecha { get; set; }
    public string? Observaciones { get; set; }
}

public class CategoriaStats
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int TotalProductos { get; set; }
    public decimal ValorInventario { get; set; }
    public int ProductosActivos { get; set; }
    public string? Color { get; set; }
    public string? Icono { get; set; }
}

public class AlertaInventario
{
    public string Tipo { get; set; } = string.Empty; // StockBajo, StockAlto, Vencimiento, Reconteo
    public string Mensaje { get; set; } = string.Empty;
    public int ProductoId { get; set; }
    public string NombreProducto { get; set; } = string.Empty;
    public string Severidad { get; set; } = string.Empty; // Alta, Media, Baja
    public DateTime FechaGeneracion { get; set; }
}

public class ReporteInventario
{
    public DateTime FechaGeneracion { get; set; } = DateTime.UtcNow;
    public int TotalProductos { get; set; }
    public int ProductosActivos { get; set; }
    public int ProductosInactivos { get; set; }
    public decimal ValorTotalInventario { get; set; }
    public List<ProductoInventario> DetalleProductos { get; set; } = new();
}

public class ProductoInventario
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Categoria { get; set; }
    public int StockActual { get; set; }
    public int StockMinimo { get; set; }
    public int StockMaximo { get; set; }
    public decimal PrecioVenta { get; set; }
    public decimal? PrecioCompra { get; set; }
    public decimal ValorStock { get; set; }
    public string? Ubicacion { get; set; }
    public DateTime? FechaUltimoMovimiento { get; set; }
    public bool RequiereAtencion { get; set; }
    public string? Estado { get; set; } // Optimo, StockBajo, StockAlto, SinStock
}
