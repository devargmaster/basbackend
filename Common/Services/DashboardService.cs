using Common.Services;
using Domain.Models.DTOs;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Common.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IRepository _repository;

        public DashboardService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<DashboardStatsResponse> GetDashboardStatsAsync()
        {
            var productos = await _repository.GetAsync<Productos>();
            var usuarios = await _repository.GetAsync<Usuarios>();
            var categorias = await _repository.GetAsync<Categorias>();
            var stocks = await _repository.GetAsync<Stock>();
            var movimientos = await _repository.GetAsync<MovimientosInventario>();

            var totalProductos = productos.Count();
            var totalUsuarios = usuarios.Count();
            var totalCategorias = categorias.Count();
            
            var productosActivos = productos.Where(p => p.Activo);
            var stocksConProductos = stocks.Where(s => productosActivos.Any(p => p.Id == s.ProductoId));
            
            var valorTotalInventario = stocksConProductos.Sum(s => s.ValorTotalStock);
            var productosStockBajo = stocksConProductos.Count(s => s.StockBajo);
            var productosStockAlto = stocksConProductos.Count(s => s.StockAlto);
            var productosInactivos = productos.Count(p => !p.Activo);
            
            var hoy = DateTime.UtcNow.Date;
            var inicioSemana = hoy.AddDays(-(int)hoy.DayOfWeek);
            var inicioMes = new DateTime(hoy.Year, hoy.Month, 1);
            
            var movimientosHoy = movimientos.Count(m => m.FechaCreacion.Date == hoy && m.Activo);
            var movimientosSemanales = movimientos.Count(m => m.FechaCreacion.Date >= inicioSemana && m.Activo);
            var movimientosMensuales = movimientos.Count(m => m.FechaCreacion.Date >= inicioMes && m.Activo);
            
            // Productos con stock bajo
            var productosConStockBajo = stocksConProductos
                .Where(s => s.StockBajo)
                .Take(5)
                .Select(s => new ProductoStockBajo
                {
                    Id = s.ProductoId,
                    Nombre = productos.FirstOrDefault(p => p.Id == s.ProductoId)?.Nombre ?? "Sin nombre",
                    StockActual = s.CantidadActual,
                    StockMinimo = s.StockMinimo,
                    Categoria = categorias.FirstOrDefault(c => c.Id == productos.FirstOrDefault(p => p.Id == s.ProductoId)?.CategoriaId)?.Nombre,
                    PrecioVenta = productos.FirstOrDefault(p => p.Id == s.ProductoId)?.Precio
                })
                .ToList();
            
            // Movimientos recientes
            var movimientosRecientes = movimientos
                .Where(m => m.Activo)
                .OrderByDescending(m => m.FechaCreacion)
                .Take(5)
                .Select(m => new MovimientoReciente
                {
                    Id = m.Id,
                    Producto = productos.FirstOrDefault(p => p.Id == m.ProductoId)?.Nombre ?? "Sin nombre",
                    TipoMovimiento = m.TipoMovimiento.ToString(),
                    Cantidad = m.Cantidad,
                    Usuario = usuarios.FirstOrDefault(u => u.Id == m.UsuarioId)?.NombreCompleto ?? "Usuario desconocido",
                    Fecha = m.FechaCreacion,
                    Observaciones = m.Observaciones
                })
                .ToList();
            
            // Top categorías
            var topCategorias = categorias
                .Where(c => c.Activo)
                .Select(c => new CategoriaStats
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    TotalProductos = productos.Count(p => p.CategoriaId == c.Id && p.Activo),
                    ProductosActivos = productos.Count(p => p.CategoriaId == c.Id && p.Activo),
                    Color = c.Color,
                    Icono = c.Icono,
                    ValorInventario = stocksConProductos
                        .Where(s => productos.Any(p => p.Id == s.ProductoId && p.CategoriaId == c.Id))
                        .Sum(s => s.ValorTotalStock)
                })
                .OrderByDescending(c => c.TotalProductos)
                .Take(5)
                .ToList();
            
            // Alertas
            var alertas = new List<AlertaInventario>();
            
            // Alertas de stock bajo
            foreach (var producto in productosConStockBajo)
            {
                alertas.Add(new AlertaInventario
                {
                    Tipo = "StockBajo",
                    Mensaje = $"El producto {producto.Nombre} tiene stock bajo ({producto.StockActual} unidades)",
                    ProductoId = producto.Id,
                    NombreProducto = producto.Nombre,
                    Severidad = producto.StockActual == 0 ? "Alta" : "Media",
                    FechaGeneracion = DateTime.UtcNow
                });
            }

            return new DashboardStatsResponse
            {
                TotalProductos = totalProductos,
                TotalUsuarios = totalUsuarios,
                TotalCategorias = totalCategorias,
                ValorTotalInventario = valorTotalInventario,
                ProductosStockBajo = productosStockBajo,
                ProductosStockAlto = productosStockAlto,
                ProductosInactivos = productosInactivos,
                MovimientosHoy = movimientosHoy,
                MovimientosSemanales = movimientosSemanales,
                MovimientosMensuales = movimientosMensuales,
                ProductosConStockBajo = productosConStockBajo,
                MovimientosRecientes = movimientosRecientes,
                TopCategorias = topCategorias,
                Alertas = alertas
            };
        }
    }
}
