using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericCommandsOperations;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;
using Common.GenericsMethods;

namespace Common.Handlers.MovimientosInventario;

public class MovimientosInventarioDeleteHandler : DeleteHandler<Domain.Models.Entities.MovimientosInventario>, IRequestHandler<DeleteCommand<Domain.Models.Entities.MovimientosInventario>, Unit>
{
    public MovimientosInventarioDeleteHandler(IRepositoryFactory repositoryFactory) : base(repositoryFactory) { }
}
