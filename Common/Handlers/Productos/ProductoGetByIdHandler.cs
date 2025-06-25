using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericResponse;
using Common.GenericsMethods.Queries;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;

namespace Common.Handlers.Productos;

public class ProductosGetByIdHandler : GetByIdHandler<Domain.Models.Entities.Productos>, IRequestHandler<GetByIdQuery<Domain.Models.Entities.Productos>, GetByIdResponse<Domain.Models.Entities.Productos>>
{
    public ProductosGetByIdHandler(IRepository repository) : base(repository) { }
}