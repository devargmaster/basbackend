using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericCommandsOperations;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;
using Common.GenericsMethods;

namespace Common.Handlers.Categorias;

public class CategoriasUpdateHandler : UpdateHandler<Domain.Models.Entities.Categorias>, IRequestHandler<UpdateCommand<Domain.Models.Entities.Categorias>, Unit>
{
    public CategoriasUpdateHandler(IRepository repository) : base(repository) { }
}