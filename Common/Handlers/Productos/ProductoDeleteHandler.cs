using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericCommandsOperations;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;
using Common.GenericsMethods;

namespace Common.Handlers.Productos;

public class ProductosDeleteHandler : DeleteHandler<Domain.Models.Entities.Productos>, IRequestHandler<DeleteCommand<Domain.Models.Entities.Productos>, Unit>
{
    public ProductosDeleteHandler(IRepositoryFactory repositoryFactory) : base(repositoryFactory) { }
}