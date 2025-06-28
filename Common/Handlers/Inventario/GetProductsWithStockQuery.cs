using Domain.Models.DTOs;
using MediatR;

namespace Common.Handlers.Inventario
{
    public class GetProductsWithStockQuery : IRequest<IEnumerable<ProductWithStockDto>>
    {
    }
}
