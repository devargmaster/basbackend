using Common.GenericsMethods;
using Common.GenericsMethods.GenericCommandsOperations;
using Common.GenericsMethods.GenericHandlers;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;

namespace Common.Usuario.Handlers;

public class UpdateHandler : UpdateHandler<Usuarios>, IRequestHandler<UpdateCommand<Usuarios>, Unit>
{
    public UpdateHandler(IRepository repository) : base(repository) { }
}
