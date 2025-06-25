using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericResponse;
using Common.GenericsMethods.Queries;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;

namespace Common.Handlers.Productos;

public class ProductosGetHandler : GetHandler<Domain.Models.Entities.Productos>, IRequestHandler<GetQuery<Domain.Models.Entities.Productos>, GetResponse<Domain.Models.Entities.Productos>>
{
    public ProductosGetHandler(IRepository repository) : base(repository) { }
}