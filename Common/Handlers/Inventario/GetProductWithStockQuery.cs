using Domain.Models.DTOs;
using MediatR;

namespace Common.Handlers.Inventario
{
    public class GetProductWithStockQuery : IRequest<ProductWithStockDto?>
    {
        public int ProductId { get; set; }

        public GetProductWithStockQuery(int productId)
        {
            ProductId = productId;
        }
    }
}
