using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericCommandsOperations;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;
using Common.GenericsMethods;

namespace Common.Handlers.Productos;

public class ProductosUpdateHandler : UpdateHandler<Domain.Models.Entities.Productos>, IRequestHandler<UpdateCommand<Domain.Models.Entities.Productos>, Unit>
{
    public ProductosUpdateHandler(IRepository repository) : base(repository) { }
}