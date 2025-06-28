using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericResponse;
using Common.GenericsMethods.Queries;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;

namespace Common.Handlers.MovimientosInventario;

public class MovimientosInventarioGetHandler : GetHandler<Domain.Models.Entities.MovimientosInventario>, IRequestHandler<GetQuery<Domain.Models.Entities.MovimientosInventario>, GetResponse<Domain.Models.Entities.MovimientosInventario>>
{
    public MovimientosInventarioGetHandler(IRepository repository) : base(repository) { }
}
