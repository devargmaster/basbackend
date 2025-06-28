using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericCommandsOperations;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;
using Common.GenericsMethods;

namespace Common.Handlers.MovimientosInventario;

public class MovimientosInventarioUpdateHandler : UpdateHandler<Domain.Models.Entities.MovimientosInventario>, IRequestHandler<UpdateCommand<Domain.Models.Entities.MovimientosInventario>, Unit>
{
    public MovimientosInventarioUpdateHandler(IRepository repository) : base(repository) { }
}
