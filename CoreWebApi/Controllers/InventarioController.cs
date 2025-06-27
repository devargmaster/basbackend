using Microsoft.AspNetCore.Mvc;
using Common.Services;
using Domain.Models.DTOs;

namespace CoreWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventarioController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventarioController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet("productos-con-stock")]
        public async Task<IActionResult> GetProductsWithStock()
        {
            try
            {
                var products = await _inventoryService.GetProductsWithStockAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener productos con stock", error = ex.Message });
            }
        }

        [HttpGet("productos/{id}/stock")]
        public async Task<IActionResult> GetProductStock(int id)
        {
            try
            {
                var stock = await _inventoryService.GetStockByProductAsync(id);
                if (stock == null)
                {
                    return NotFound(new { message = "Stock no encontrado para el producto" });
                }
                return Ok(stock);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener stock del producto", error = ex.Message });
            }
        }

        [HttpPut("productos/{id}/stock")]
        public async Task<IActionResult> UpdateStock(int id, [FromBody] UpdateStockRequest request)
        {
            try
            {
                var result = await _inventoryService.UpdateStockAsync(id, request);
                if (!result)
                {
                    return BadRequest(new { message = "Error al actualizar stock" });
                }
                return Ok(new { message = "Stock actualizado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al actualizar stock", error = ex.Message });
            }
        }

        [HttpPost("movimientos")]
        public async Task<IActionResult> CreateMovement([FromBody] CreateMovementRequest request)
        {
            try
            {
                var result = await _inventoryService.CreateMovementAsync(request);
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

        [HttpGet("movimientos")]
        public async Task<IActionResult> GetMovements()
        {
            try
            {
                var movements = await _inventoryService.GetMovementsAsync();
                return Ok(movements);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener movimientos", error = ex.Message });
            }
        }

        [HttpGet("productos/{id}/movimientos")]
        public async Task<IActionResult> GetProductMovements(int id)
        {
            try
            {
                var movements = await _inventoryService.GetMovementsByProductAsync(id);
                return Ok(movements);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener movimientos del producto", error = ex.Message });
            }
        }

        [HttpGet("movimientos/recientes")]
        public async Task<IActionResult> GetRecentMovements([FromQuery] int count = 10)
        {
            try
            {
                var movements = await _inventoryService.GetRecentMovementsAsync(count);
                return Ok(movements);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener movimientos recientes", error = ex.Message });
            }
        }
    }
}