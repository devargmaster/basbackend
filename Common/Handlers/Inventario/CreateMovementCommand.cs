using Domain.Models.DTOs;
using MediatR;

namespace Common.Handlers.Inventario
{
    public class CreateMovementCommand : IRequest<bool>
    {
        public CreateMovementRequest Request { get; set; }

        public CreateMovementCommand(CreateMovementRequest request)
        {
            Request = request;
        }
    }
}
