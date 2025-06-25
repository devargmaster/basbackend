using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericCommandsOperations;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;
using Common.GenericsMethods.GenericResponse;

namespace Common.Handlers.Productos;

public class ProductosCreateHandler : CreateHandler<Domain.Models.Entities.Productos>, IRequestHandler<CreateCommand<Domain.Models.Entities.Productos>, CreateResponse<Domain.Models.Entities.Productos>>
{
    public ProductosCreateHandler(IRepository repository) : base(repository) { }
}