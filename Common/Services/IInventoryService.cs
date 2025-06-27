using Domain.Models.DTOs;

namespace Common.Services;

public interface IInventoryService
{
    Task<IEnumerable<ProductWithStockDto>> GetProductsWithStockAsync();
    Task<ProductWithStockDto?> GetProductWithStockAsync(int productId);
    Task<StockDto?> GetStockByProductAsync(int productId);
    Task<bool> UpdateStockAsync(int productId, UpdateStockRequest request);
    Task<bool> CreateMovementAsync(CreateMovementRequest request);
    Task<IEnumerable<MovementDto>> GetMovementsAsync();
    Task<IEnumerable<MovementDto>> GetMovementsByProductAsync(int productId);
    Task<IEnumerable<MovementDto>> GetRecentMovementsAsync(int count = 10);
}
