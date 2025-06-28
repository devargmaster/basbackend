using Common.Handlers.Inventario;
using Domain.Models.DTOs;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;

namespace Common.Handlers.Inventario
{
    public class GetRecentMovementsHandler : IRequestHandler<GetRecentMovementsQuery, IEnumerable<MovementDto>>
    {
        private readonly IRepository _repository;

        public GetRecentMovementsHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MovementDto>> Handle(GetRecentMovementsQuery request, CancellationToken cancellationToken)
        {
            var movimientos = await _repository.GetAsync<Domain.Models.Entities.MovimientosInventario>();
            var productos = await _repository.GetAsync<Domain.Models.Entities.Productos>();
            var usuarios = await _repository.GetAsync<Domain.Models.Entities.Usuarios>();

            var result = movimientos
                .Where(m => m.Activo)
                .OrderByDescending(m => m.FechaCreacion)
                .Take(request.Count)
                .Select(m => new MovementDto
                {
                    Id = m.Id,
                    ProductoId = m.ProductoId,
                    ProductoNombre = productos.FirstOrDefault(p => p.Id == m.ProductoId)?.Nombre ?? "Producto no encontrado",
                    UsuarioId = m.UsuarioId,
                    UsuarioNombre = usuarios.FirstOrDefault(u => u.Id == m.UsuarioId)?.NombreCompleto ?? "Usuario no encontrado",
                    TipoMovimiento = m.TipoMovimiento.ToString(),
                    CantidadAnterior = m.StockAnterior,
                    CantidadMovimiento = m.Cantidad,
                    CantidadFinal = m.StockActual,
                    Motivo = m.Observaciones,
                    NumeroDocumento = m.DocumentoReferencia,
                    FechaMovimiento = m.FechaCreacion
                })
                .ToList();

            return result;
        }
    }
}
