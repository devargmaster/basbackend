using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericCommandsOperations;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;
using Common.GenericsMethods.GenericResponse;

namespace Common.Handlers.Categorias;

public class CategoriasCreateHandler : CreateHandler<Domain.Models.Entities.Categorias>, IRequestHandler<CreateCommand<Domain.Models.Entities.Categorias>, CreateResponse<Domain.Models.Entities.Categorias>>
{
    public CategoriasCreateHandler(IRepository repository) : base(repository) { }
}