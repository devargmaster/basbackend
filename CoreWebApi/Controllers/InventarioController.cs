using Microsoft.AspNetCore.Mvc;
using Common.Handlers.Inventario;
using Domain.Models.DTOs;
using MediatR;

namespace CoreWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InventarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("productos-con-stock")]
        public async Task<IActionResult> GetProductsWithStock()
        {
            try
            {
                var products = await _mediator.Send(new GetProductsWithStockQuery());
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener productos con stock", error = ex.Message });
            }
        }

        [HttpGet("productos/{id}")]
        public async Task<IActionResult> GetProductWithStock(int id)
        {
            try
            {
                var product = await _mediator.Send(new GetProductWithStockQuery(id));
                if (product == null)
                {
                    return NotFound(new { message = "Producto no encontrado" });
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener producto con stock", error = ex.Message });
            }
        }

        [HttpGet("movimientos/recientes")]
        public async Task<IActionResult> GetRecentMovements([FromQuery] int count = 10)
        {
            try
            {
                var movements = await _mediator.Send(new GetRecentMovementsQuery(count));
                return Ok(movements);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener movimientos recientes", error = ex.Message });
            }
        }

        [HttpPost("movimientos")]
        public async Task<IActionResult> CreateMovement([FromBody] CreateMovementRequest request)
        {
            try
            {
                var result = await _mediator.Send(new CreateMovementCommand(request));
                if (!result)
                {
                    return BadRequest(new { message = "Error al crear movimiento de inventario" });
                }
                return Ok(new { message = "Movimiento de inventario creado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al crear movimiento", error = ex.Message });
            }
        }

        // DEPRECATED ENDPOINTS - USE GENERIC CONTROLLERS INSTEAD:
        // - GET /api/inventario/productos/{id}/stock -> Use GET /api/stock?filter=productoId:{id}
        // - PUT /api/inventario/productos/{id}/stock -> Use PUT /api/stock/{stockId}
        // - GET /api/inventario/movimientos -> Use GET /api/movimientosinventario
        // - GET /api/inventario/productos/{id}/movimientos -> Use GET /api/movimientosinventario?filter=productoId:{id}
    }
}