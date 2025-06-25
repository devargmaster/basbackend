using Common.GenericsMethods;
using Common.GenericsMethods.GenericCommandsOperations;
using Common.GenericsMethods.GenericHandlers;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;

namespace Common.Usuario.Handlers;

public class DeleteHandler : DeleteHandler<Usuarios>, IRequestHandler<DeleteCommand<Usuarios>, Unit>
{
    public DeleteHandler(IRepositoryFactory repositoryFactory) : base(repositoryFactory) { }
}