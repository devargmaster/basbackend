using Domain.Models.DTOs;
using MediatR;

namespace Common.Handlers.Inventario
{
    public class GetRecentMovementsQuery : IRequest<IEnumerable<MovementDto>>
    {
        public int Count { get; set; }

        public GetRecentMovementsQuery(int count = 10)
        {
            Count = count;
        }
    }
}
