using Common.Handlers.Inventario;
using Domain.Models.DTOs;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;

namespace Common.Handlers.Inventario
{
    public class GetProductsWithStockHandler : IRequestHandler<GetProductsWithStockQuery, IEnumerable<ProductWithStockDto>>
    {
        private readonly IRepository _repository;

        public GetProductsWithStockHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductWithStockDto>> Handle(GetProductsWithStockQuery request, CancellationToken cancellationToken)
        {
            var productos = await _repository.GetAsync<Domain.Models.Entities.Productos>();
            var stocks = await _repository.GetAsync<Domain.Models.Entities.Stock>();
            var categorias = await _repository.GetAsync<Domain.Models.Entities.Categorias>();

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
    }
}
