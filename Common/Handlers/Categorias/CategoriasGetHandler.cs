using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericResponse;
using Common.GenericsMethods.Queries;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;

namespace Common.Handlers.Categorias;

public class CategoriasGetHandler : GetHandler<Domain.Models.Entities.Categorias>, IRequestHandler<GetQuery<Domain.Models.Entities.Categorias>, GetResponse<Domain.Models.Entities.Categorias>>
{
    public CategoriasGetHandler(IRepository repository) : base(repository) { }
}