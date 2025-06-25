using System;
using Common.GenericsMethods.GenericHandlers;
using Common.GenericsMethods.GenericResponse;
using Common.GenericsMethods.Queries;
using Domain.Models.Entities;
using Infraestructure.Repositories;
using MediatR;

namespace Common.Handlers.Usuario;

public class GetHandler : GetHandler<Usuarios>, IRequestHandler<GetQuery<Usuarios>, GetResponse<Usuarios>>
{
    public GetHandler(IRepository repository) : base(repository) { }

}
