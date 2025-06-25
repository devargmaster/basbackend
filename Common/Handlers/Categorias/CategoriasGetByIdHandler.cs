using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericResponse;
using Common.GenericsMethods.Queries;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;

namespace Common.Handlers.Categorias;

public class CategoriasGetByIdHandler : GetByIdHandler<Domain.Models.Entities.Categorias>, IRequestHandler<GetByIdQuery<Domain.Models.Entities.Categorias>, GetByIdResponse<Domain.Models.Entities.Categorias>>
{
    public CategoriasGetByIdHandler(IRepository repository) : base(repository) { }
}