using Domain.Models.DTOs;
using MediatR;

namespace Common.Handlers.Inventario
{
    public class GetAllMovementsQuery : IRequest<IEnumerable<MovementDto>>
    {
    }
}
