using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericResponse;
using Common.GenericsMethods.Queries;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;

namespace Common.Usuario.Handlers;

public class UsuariosGetByIdHandler : GetByIdHandler<Usuarios>, IRequestHandler<GetByIdQuery<Usuarios>, GetByIdResponse<Usuarios>>
{
    public UsuariosGetByIdHandler(IRepository repository) : base(repository) { }
}