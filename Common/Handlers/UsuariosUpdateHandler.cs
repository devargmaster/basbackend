using Common.GenericsMethods;
using Common.GenericsMethods.GenericCommandsOperations;
using Common.GenericsMethods.GenericHandlers;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;

namespace Common.Handlers;

public class UsuariosUpdateHandler : UpdateHandler<Usuarios>, IRequestHandler<UpdateCommand<Usuarios>, Unit>
{
    public UsuariosUpdateHandler(IRepository repository) : base(repository) { }
}
