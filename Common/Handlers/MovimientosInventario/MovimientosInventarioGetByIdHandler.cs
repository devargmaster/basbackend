using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericResponse;
using Common.GenericsMethods.Queries;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;

namespace Common.Handlers.MovimientosInventario;

public class MovimientosInventarioGetByIdHandler : GetByIdHandler<Domain.Models.Entities.MovimientosInventario>, IRequestHandler<GetByIdQuery<Domain.Models.Entities.MovimientosInventario>, GetByIdResponse<Domain.Models.Entities.MovimientosInventario>>
{
    public MovimientosInventarioGetByIdHandler(IRepository repository) : base(repository) { }
}
