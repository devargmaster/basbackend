using Common.GenericsMethods;
using Common.GenericsMethods.GenericCommandsOperations;
using Common.GenericsMethods.GenericHandlers;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;

namespace Common.Handlers.Usuarios;

public class UsuaiosDeleteHandler : DeleteHandler<Domain.Models.Entities.Usuarios>, IRequestHandler<DeleteCommand<Domain.Models.Entities.Usuarios>, Unit>
{
    public UsuaiosDeleteHandler(IRepositoryFactory repositoryFactory) : base(repositoryFactory) { }
}