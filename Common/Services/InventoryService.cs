using Domain.Models.DTOs;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Common.Services;

public class InventoryService : IInventoryService
{
    private readonly IRepository _repository;

    public InventoryService(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ProductWithStockDto>> GetProductsWithStockAsync()
    {
        var productos = await _repository.GetAsync<Productos>();
        var stocks = await _repository.GetAsync<Stock>();
        var categorias = await _repository.GetAsync<Categorias>();

        var result = from p in productos
                     join s in stocks on p.Id equals s.ProductoId into stockGroup
                     from stock in stockGroup.DefaultIfEmpty()
                     join c in categorias on p.CategoriaId equals c.Id into catGroup
                     from categoria in catGroup.DefaultIfEmpty()
                     where p.Activo
                     select new ProductWithStockDto
                     {
                         Id = p.Id,
                         Nombre = p.Nombre,
                         Descripcion = p.Descripcion,
                         Precio = p.Precio,
                         CategoriaId = p.CategoriaId ?? 0,
                         CategoriaNombre = categoria?.Nombre ?? "Sin categoría",
                         Marca = p.Marca,
                         CodigoBarras = p.CodigoBarras,
                         UnidadMedida = p.UnidadMedida,
                         Proveedor = p.Proveedor,
                         PrecioCompra = p.PrecioCompra,
                         StockActual = stock?.CantidadActual ?? 0,
                         StockMinimo = stock?.StockMinimo ?? 0,
                         StockMaximo = stock?.StockMaximo ?? 100,
                         UbicacionFisica = stock?.Ubicacion,
                         FechaUltimoMovimiento = stock?.FechaUltimoMovimiento,
                         AlertaStockBajo = stock != null && stock.CantidadActual <= stock.StockMinimo
                     };

        return result.ToList();
    }

    public async Task<ProductWithStockDto?> GetProductWithStockAsync(int productId)
    {
        var productos = await GetProductsWithStockAsync();
        return productos.FirstOrDefault(p => p.Id == productId);
    }

    public async Task<StockDto?> GetStockByProductAsync(int productId)
    {
        var stocks = await _repository.GetAsync<Stock>();
        var stock = stocks.FirstOrDefault(s => s.ProductoId == productId);

        if (stock == null) return null;

        return new StockDto
        {
            Id = stock.Id,
            ProductoId = stock.ProductoId,
            CantidadActual = stock.CantidadActual,
            StockMinimo = stock.StockMinimo,
            StockMaximo = stock.StockMaximo,
            Ubicacion = stock.Ubicacion,
            FechaUltimaModificacion = stock.FechaModificacion
        };
    }

    public async Task<bool> UpdateStockAsync(int productId, UpdateStockRequest request)
    {
        try
        {
            var stocks = await _repository.GetAsync<Stock>();
            var stock = stocks.FirstOrDefault(s => s.ProductoId == productId);

            if (stock == null)
            {
                // Crear nuevo registro de stock
                stock = new Stock
                {
                    ProductoId = productId,
                    CantidadActual = request.CantidadNueva,
                    StockMinimo = request.StockMinimo ?? 10,
                    StockMaximo = request.StockMaximo ?? 100,
                    Ubicacion = request.UbicacionFisica,
                    FechaCreacion = DateTime.UtcNow,
                    Activo = true
                };

                await _repository.CreateAsync(stock);
            }
            else
            {
                // Actualizar stock existente
                stock.CantidadActual = request.CantidadNueva;
                if (request.StockMinimo.HasValue) stock.StockMinimo = request.StockMinimo.Value;
                if (request.StockMaximo.HasValue) stock.StockMaximo = request.StockMaximo.Value;
                if (!string.IsNullOrEmpty(request.UbicacionFisica)) stock.Ubicacion = request.UbicacionFisica;
                stock.FechaModificacion = DateTime.UtcNow;

                await _repository.UpdateAsync(stock);
            }

            // Crear movimiento de inventario
            var movimiento = new MovimientosInventario
            {
                ProductoId = productId,
                TipoMovimiento = Enum.TryParse<Domain.Models.Entities.TipoMovimiento>(request.TipoMovimiento ?? "Ajuste", out var tipo) ? tipo : Domain.Models.Entities.TipoMovimiento.Ajuste,
                StockAnterior = stocks.FirstOrDefault(s => s.ProductoId == productId)?.CantidadActual ?? 0,
                Cantidad = Math.Abs(request.CantidadNueva - (stocks.FirstOrDefault(s => s.ProductoId == productId)?.CantidadActual ?? 0)),
                StockActual = request.CantidadNueva,
                Observaciones = request.Motivo ?? "Actualización de stock",
                UsuarioId = request.UsuarioId ?? 1,
                FechaCreacion = DateTime.UtcNow,
                Activo = true
            };

            await _repository.CreateAsync(movimiento);

            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> CreateMovementAsync(CreateMovementRequest request)
    {
        try
        {
            var stocks = await _repository.GetAsync<Stock>();
            var stock = stocks.FirstOrDefault(s => s.ProductoId == request.ProductoId);

            if (stock == null) return false;

            var cantidadAnterior = stock.CantidadActual;
            var cantidadFinal = request.TipoMovimiento.ToLower() switch
            {
                "entrada" => cantidadAnterior + request.Cantidad,
                "salida" => cantidadAnterior - request.Cantidad,
                "ajuste" => request.Cantidad,
                _ => cantidadAnterior
            };

            // Actualizar stock
            stock.CantidadActual = cantidadFinal;
            stock.FechaModificacion = DateTime.UtcNow;
            await _repository.UpdateAsync(stock);

            // Crear movimiento
            var movimiento = new MovimientosInventario
            {
                ProductoId = request.ProductoId,
                TipoMovimiento = Enum.TryParse<Domain.Models.Entities.TipoMovimiento>(request.TipoMovimiento, out var tipo) ? tipo : Domain.Models.Entities.TipoMovimiento.Ajuste,
                StockAnterior = cantidadAnterior,
                Cantidad = request.TipoMovimiento.ToLower() == "salida" ? -request.Cantidad : request.Cantidad,
                StockActual = cantidadFinal,
                Observaciones = request.Motivo,
                UsuarioId = request.UsuarioId,
                DocumentoReferencia = request.NumeroDocumento,
                FechaCreacion = DateTime.UtcNow,
                Activo = true
            };

            await _repository.CreateAsync(movimiento);

            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<IEnumerable<MovementDto>> GetMovementsAsync()
    {
        var movimientos = await _repository.GetAsync<MovimientosInventario>();
        var productos = await _repository.GetAsync<Productos>();
        var usuarios = await _repository.GetAsync<Usuarios>();

        var result = from m in movimientos
                     join p in productos on m.ProductoId equals p.Id into prodGroup
                     from producto in prodGroup.DefaultIfEmpty()
                     join u in usuarios on m.UsuarioId equals u.Id into userGroup
                     from usuario in userGroup.DefaultIfEmpty()
                     where m.Activo
                     orderby m.FechaCreacion descending
                     select new MovementDto
                     {
                         Id = m.Id,
                         ProductoId = m.ProductoId,
                         ProductoNombre = producto?.Nombre ?? "Producto eliminado",
                         TipoMovimiento = m.TipoMovimiento.ToString(),
                         CantidadAnterior = m.StockAnterior,
                         CantidadMovimiento = m.Cantidad,
                         CantidadFinal = m.StockActual,
                         Motivo = m.Observaciones,
                         UsuarioId = m.UsuarioId,
                         UsuarioNombre = usuario != null ? $"{usuario.Nombre} {usuario.Apellido}" : "Usuario eliminado",
                         NumeroDocumento = m.DocumentoReferencia,
                         FechaMovimiento = m.FechaCreacion
                     };

        return result.ToList();
    }

    public async Task<IEnumerable<MovementDto>> GetMovementsByProductAsync(int productId)
    {
        var movements = await GetMovementsAsync();
        return movements.Where(m => m.ProductoId == productId);
    }

    public async Task<IEnumerable<MovementDto>> GetRecentMovementsAsync(int count = 10)
    {
        var movements = await GetMovementsAsync();
        return movements.Take(count);
    }
}
