using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericCommandsOperations;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;
using Common.GenericsMethods.GenericResponse;

namespace Common.Handlers.MovimientosInventario;

public class MovimientosInventarioCreateHandler : CreateHandler<Domain.Models.Entities.MovimientosInventario>, IRequestHandler<CreateCommand<Domain.Models.Entities.MovimientosInventario>, CreateResponse<Domain.Models.Entities.MovimientosInventario>>
{
    public MovimientosInventarioCreateHandler(IRepository repository) : base(repository) { }
}
