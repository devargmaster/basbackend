using System;
using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericResponse;
using Common.GenericsMethods.Queries;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;

namespace Common.Usuario.Handlers;

public class UsuariosGetHandler : GetHandler<Usuarios>, IRequestHandler<GetQuery<Usuarios>, GetResponse<Usuarios>>
{
    public UsuariosGetHandler(IRepository repository) : base(repository) { }

}
