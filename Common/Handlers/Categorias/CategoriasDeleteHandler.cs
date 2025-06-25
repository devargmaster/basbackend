using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericCommandsOperations;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;
using Common.GenericsMethods;

namespace Common.Handlers.Categorias;

public class CategoriasDeleteHandler : DeleteHandler<Domain.Models.Entities.Categorias>, IRequestHandler<DeleteCommand<Domain.Models.Entities.Categorias>, Unit>
{
    public CategoriasDeleteHandler(IRepositoryFactory repositoryFactory) : base(repositoryFactory) { }
}