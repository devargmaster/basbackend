using Common.Handlers.Inventario;
using Domain.Models.DTOs;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;

namespace Common.Handlers.Inventario
{
    public class CreateMovementHandler : IRequestHandler<CreateMovementCommand, bool>
    {
        private readonly IRepository _repository;

        public CreateMovementHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateMovementCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Convertir CreateMovementRequest a MovimientosInventario entity
                var movimiento = new Domain.Models.Entities.MovimientosInventario
                {
                    ProductoId = request.Request.ProductoId,
                    UsuarioId = request.Request.UsuarioId,
                    TipoMovimiento = GetTipoMovimientoEnum(request.Request.TipoMovimiento),
                    Cantidad = request.Request.Cantidad,
                    Observaciones = request.Request.Motivo,
                    DocumentoReferencia = request.Request.NumeroDocumento,
                    FechaCreacion = DateTime.UtcNow,
                    Activo = true
                };

                // Calcular stock anterior y actual
                var stocks = await _repository.GetAsync<Domain.Models.Entities.Stock>();
                var stock = stocks.FirstOrDefault(s => s.ProductoId == request.Request.ProductoId);
                
                if (stock != null)
                {
                    movimiento.StockAnterior = stock.CantidadActual;
                    
                    // Calcular el nuevo stock según el tipo de movimiento
                    var nuevoStock = movimiento.TipoMovimiento switch
                    {
                        Domain.Models.Entities.TipoMovimiento.Entrada => stock.CantidadActual + request.Request.Cantidad,
                        Domain.Models.Entities.TipoMovimiento.Salida => stock.CantidadActual - request.Request.Cantidad,
                        Domain.Models.Entities.TipoMovimiento.Ajuste => request.Request.Cantidad,
                        _ => stock.CantidadActual
                    };

                    movimiento.StockActual = nuevoStock;

                    // Actualizar el stock
                    stock.CantidadActual = nuevoStock;
                    stock.FechaModificacion = DateTime.UtcNow;
                    await _repository.UpdateAsync(stock);
                }
                else
                {
                    movimiento.StockAnterior = 0;
                    movimiento.StockActual = request.Request.Cantidad;
                }

                // Crear el movimiento directamente
                await _repository.CreateAsync(movimiento);

                return true;
            }
            catch
            {
                return false;
            }
        }

        private Domain.Models.Entities.TipoMovimiento GetTipoMovimientoEnum(string tipoMovimiento)
        {
            return tipoMovimiento?.ToLower() switch
            {
                "entrada" or "compra" or "1" => Domain.Models.Entities.TipoMovimiento.Entrada,
                "salida" or "venta" or "2" => Domain.Models.Entities.TipoMovimiento.Salida,
                "ajuste" or "3" => Domain.Models.Entities.TipoMovimiento.Ajuste,
                _ => Domain.Models.Entities.TipoMovimiento.Ajuste
            };
        }
    }
}
