namespace Domain.Models.DTOs;

// DTOs para Productos
public class ProductoDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public decimal Precio { get; set; }
    public string? ImagenUrl { get; set; }
    public int? CategoriaId { get; set; }
    public string? CategoriaNombre { get; set; }
    public string? Marca { get; set; }
    public string? CodigoBarras { get; set; }
    public string? UnidadMedida { get; set; }
    public string? Proveedor { get; set; }
    public string? Observaciones { get; set; }
    public decimal? Peso { get; set; }
    public decimal? Largo { get; set; }
    public decimal? Ancho { get; set; }
    public decimal? Alto { get; set; }
    public decimal? PrecioCompra { get; set; }
    public decimal? PrecioMayoreo { get; set; }
    public string? CodigoSAT { get; set; }
    public decimal IVA { get; set; }
    public bool Activo { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime? FechaModificacion { get; set; }
    
    // Información de stock
    public StockInfo? Stock { get; set; }
}

public class StockInfo
{
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
    public bool StockBajo { get; set; }
    public bool StockAlto { get; set; }
    public bool RequiereReconteo { get; set; }
}

public class CreateProductoDto
{
    public required string Nombre { get; set; }
    public string? Descripcion { get; set; }
    public required decimal Precio { get; set; }
    public string? ImagenUrl { get; set; }
    public int? CategoriaId { get; set; }
    public string? Marca { get; set; }
    public string? CodigoBarras { get; set; }
    public string? UnidadMedida { get; set; }
    public string? Proveedor { get; set; }
    public string? Observaciones { get; set; }
    public decimal? Peso { get; set; }
    public decimal? Largo { get; set; }
    public decimal? Ancho { get; set; }
    public decimal? Alto { get; set; }
    public decimal? PrecioCompra { get; set; }
    public decimal? PrecioMayoreo { get; set; }
    public string? CodigoSAT { get; set; }
    public decimal? IVA { get; set; }
    
    // Stock inicial
    public int? StockInicial { get; set; }
    public int? StockMinimo { get; set; }
    public int? StockMaximo { get; set; }
    public string? Ubicacion { get; set; }
    public decimal? CostoUnitario { get; set; }
}

public class UpdateProductoDto
{
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public decimal? Precio { get; set; }
    public string? ImagenUrl { get; set; }
    public int? CategoriaId { get; set; }
    public string? Marca { get; set; }
    public string? CodigoBarras { get; set; }
    public string? UnidadMedida { get; set; }
    public string? Proveedor { get; set; }
    public string? Observaciones { get; set; }
    public decimal? Peso { get; set; }
    public decimal? Largo { get; set; }
    public decimal? Ancho { get; set; }
    public decimal? Alto { get; set; }
    public decimal? PrecioCompra { get; set; }
    public decimal? PrecioMayoreo { get; set; }
    public string? CodigoSAT { get; set; }
    public decimal? IVA { get; set; }
    public bool? Activo { get; set; }
}

// DTOs para Categorías
public class CategoriaDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public string? Codigo { get; set; }
    public string? Color { get; set; }
    public string? Icono { get; set; }
    public int Orden { get; set; }
    public bool Activo { get; set; }
    public DateTime FechaCreacion { get; set; }
    public int TotalProductos { get; set; }
}

public class CreateCategoriaDto
{
    public required string Nombre { get; set; }
    public string? Descripcion { get; set; }
    public string? Codigo { get; set; }
    public string? Color { get; set; }
    public string? Icono { get; set; }
    public int? Orden { get; set; }
}

public class UpdateCategoriaDto
{
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public string? Codigo { get; set; }
    public string? Color { get; set; }
    public string? Icono { get; set; }
    public int? Orden { get; set; }
    public bool? Activo { get; set; }
}
