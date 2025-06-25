using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericCommandsOperations;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;
using Common.GenericsMethods;

namespace Common.Handlers.Inventario;

public class InventarioDeleteHandler : DeleteHandler<Domain.Models.Entities.Inventario>, IRequestHandler<DeleteCommand<Domain.Models.Entities.Inventario>, Unit>
{
    public InventarioDeleteHandler(IRepositoryFactory repositoryFactory) : base(repositoryFactory) { }
}
