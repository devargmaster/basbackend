using Domain.Models.Entities;

namespace Domain.Models.DTOs;

// DTOs para Roles
public class RolDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public bool PuedeGestionarUsuarios { get; set; }
    public bool PuedeGestionarProductos { get; set; }
    public bool PuedeGestionarInventario { get; set; }
    public bool PuedeVerReportes { get; set; }
    public bool EsAdministrador { get; set; }
    public bool Activo { get; set; }
}

public class CreateRolDto
{
    public required string Nombre { get; set; }
    public string? Descripcion { get; set; }
    public bool PuedeGestionarUsuarios { get; set; } = false;
    public bool PuedeGestionarProductos { get; set; } = false;
    public bool PuedeGestionarInventario { get; set; } = false;
    public bool PuedeVerReportes { get; set; } = false;
    public bool EsAdministrador { get; set; } = false;
}

public class UpdateRolDto
{
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public bool? PuedeGestionarUsuarios { get; set; }
    public bool? PuedeGestionarProductos { get; set; }
    public bool? PuedeGestionarInventario { get; set; }
    public bool? PuedeVerReportes { get; set; }
    public bool? EsAdministrador { get; set; }
    public bool? Activo { get; set; }
}

// DTOs para Stock
public class StockDto
{
    public int Id { get; set; }
    public int ProductoId { get; set; }
    public string NombreProducto { get; set; } = string.Empty;
    public int CantidadActual { get; set; }
    public int CantidadReservada { get; set; }
    public int CantidadDisponible { get; set; }
    public int StockMinimo { get; set; }
    public int StockMaximo { get; set; }
    public string? Ubicacion { get; set; }
    public string? Lote { get; set; }
    public DateTime? FechaVencimiento { get; set; }
    public decimal CostoUnitarioPromedio { get; set; }
    public decimal ValorTotalStock { get; set; }
    public DateTime? FechaUltimaModificacion { get; set; }
    public DateTime? FechaUltimoReconteo { get; set; }
    public bool RequiereReconteo { get; set; }
    public bool StockBajo { get; set; }
    public bool StockAlto { get; set; }
}

public class UpdateStockDto
{
    public int? CantidadActual { get; set; }
    public int? CantidadReservada { get; set; }
    public int? StockMinimo { get; set; }
    public int? StockMaximo { get; set; }
    public string? Ubicacion { get; set; }
    public string? Lote { get; set; }
    public DateTime? FechaVencimiento { get; set; }
    public decimal? CostoUnitarioPromedio { get; set; }
    public bool? RequiereReconteo { get; set; }
}

// DTOs para MovimientosInventario
public class MovimientoInventarioDto
{
    public int Id { get; set; }
    public int ProductoId { get; set; }
    public string NombreProducto { get; set; } = string.Empty;
    public int UsuarioId { get; set; }
    public string NombreUsuario { get; set; } = string.Empty;
    public TipoMovimiento TipoMovimiento { get; set; }
    public string TipoMovimientoNombre => TipoMovimiento.ToString();
    public int Cantidad { get; set; }
    public int StockAnterior { get; set; }
    public int StockActual { get; set; }
    public string? Observaciones { get; set; }
    public string? DocumentoReferencia { get; set; }
    public string? Proveedor { get; set; }
    public string? Cliente { get; set; }
    public decimal? Costo { get; set; }
    public decimal? MontoTotal { get; set; }
    public DateTime FechaCreacion { get; set; }
    public bool Activo { get; set; }
}

public class CreateMovimientoInventarioDto
{
    public required int ProductoId { get; set; }
    public required int UsuarioId { get; set; }
    public required TipoMovimiento TipoMovimiento { get; set; }
    public required int Cantidad { get; set; }
    public string? Observaciones { get; set; }
    public string? DocumentoReferencia { get; set; }
    public string? Proveedor { get; set; }
    public string? Cliente { get; set; }
    public decimal? Costo { get; set; }
}

// DTOs for Inventory Service
public class ProductWithStockDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public decimal Precio { get; set; }
    public int CategoriaId { get; set; }
    public string CategoriaNombre { get; set; } = string.Empty;
    public string? Marca { get; set; }
    public string? CodigoBarras { get; set; }
    public string? UnidadMedida { get; set; }
    public string? Proveedor { get; set; }
    public decimal? PrecioCompra { get; set; }
    public int StockActual { get; set; }
    public int StockMinimo { get; set; }
    public int StockMaximo { get; set; }
    public string? UbicacionFisica { get; set; }
    public DateTime? FechaUltimoMovimiento { get; set; }
    public bool AlertaStockBajo { get; set; }
}

public class UpdateStockRequest
{
    public int CantidadNueva { get; set; }
    public int? StockMinimo { get; set; }
    public int? StockMaximo { get; set; }
    public string? UbicacionFisica { get; set; }
    public string? TipoMovimiento { get; set; }
    public string? Motivo { get; set; }
    public int? UsuarioId { get; set; }
}

public class CreateMovementRequest
{
    public int ProductoId { get; set; }
    public string TipoMovimiento { get; set; } = string.Empty;
    public int Cantidad { get; set; }
    public string? Motivo { get; set; }
    public int UsuarioId { get; set; }
    public string? NumeroDocumento { get; set; }
}

public class MovementDto
{
    public int Id { get; set; }
    public int ProductoId { get; set; }
    public string ProductoNombre { get; set; } = string.Empty;
    public string TipoMovimiento { get; set; } = string.Empty;
    public int CantidadAnterior { get; set; }
    public int CantidadMovimiento { get; set; }
    public int CantidadFinal { get; set; }
    public string? Motivo { get; set; }
    public int UsuarioId { get; set; }
    public string UsuarioNombre { get; set; } = string.Empty;
    public string? NumeroDocumento { get; set; }
    public DateTime FechaMovimiento { get; set; }
}
