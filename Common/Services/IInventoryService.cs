using Domain.Models.DTOs;

namespace Common.Services;

public interface IInventoryService
{
    // Métodos con valor agregado - combinan múltiples entidades
    Task<IEnumerable<ProductWithStockDto>> GetProductsWithStockAsync();
    Task<ProductWithStockDto?> GetProductWithStockAsync(int productId);
    
    // Métodos que mantienen lógica de negocio específica
    Task<IEnumerable<MovementDto>> GetRecentMovementsAsync(int count = 10);
    
    // DEPRECATED: Usar controladores genéricos en su lugar
    // Task<StockDto?> GetStockByProductAsync(int productId); -> GET /api/stock/{id}
    // Task<bool> UpdateStockAsync(int productId, UpdateStockRequest request); -> PUT /api/stock/{id}
    // Task<bool> CreateMovementAsync(CreateMovementRequest request); -> POST /api/movimientosinventario
    // Task<IEnumerable<MovementDto>> GetMovementsAsync(); -> GET /api/movimientosinventario
    // Task<IEnumerable<MovementDto>> GetMovementsByProductAsync(int productId); -> GET /api/movimientosinventario?filter=productoId
}
