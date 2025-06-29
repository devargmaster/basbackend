using Microsoft.AspNetCore.Mvc;
using Common.Handlers.Inventario;
using Domain.Models.DTOs;
using Domain.Models.Entities;
using MediatR;
using Common;

namespace CoreWebApi.Controllers
{
    public class InventarioController : BaseController<MovimientosInventario>
    {
        private readonly IMediator _mediator;

        public InventarioController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("productos-con-stock")]
        public async Task<IActionResult> GetProductsWithStock()
        {
            var products = await _mediator.Send(new GetProductsWithStockQuery());
            return Ok(products);
        }

        [HttpGet("productos/{id}")]
        public async Task<IActionResult> GetProductWithStock(int id)
        {
            var product = await _mediator.Send(new GetProductWithStockQuery(id));
            if (product == null)
            {
                return NotFound(new { message = "Producto no encontrado" });
            }
            return Ok(product);
        }

        [HttpGet("movimientos/recientes")]
        public async Task<IActionResult> GetRecentMovements([FromQuery] int count = 10)
        {
            var movements = await _mediator.Send(new GetRecentMovementsQuery(count));
            return Ok(movements);
        }

        [HttpGet("movimientos")]
        public async Task<IActionResult> GetAllMovements()
        {
            var movements = await _mediator.Send(new GetAllMovementsQuery());
            return Ok(movements);
        }

        [HttpPost("movimientos")]
        public async Task<IActionResult> CreateMovement([FromBody] CreateMovementRequest request)
        {
            var result = await _mediator.Send(new CreateMovementCommand(request));
            if (!result)
            {
                return BadRequest(new { message = "Error al crear movimiento de inventario" });
            }
            return Ok(new { message = "Movimiento de inventario creado correctamente" });
        }

        // DEPRECATED ENDPOINTS - USE GENERIC CONTROLLERS INSTEAD:
        // - GET /api/inventario/productos/{id}/stock -> Use GET /api/stock?filter=productoId:{id}
        // - PUT /api/inventario/productos/{id}/stock -> Use PUT /api/stock/{stockId}
        // - GET /api/inventario/movimientos -> Use GET /api/movimientosinventario
        // - GET /api/inventario/productos/{id}/movimientos -> Use GET /api/movimientosinventario?filter=productoId:{id}
    }
}