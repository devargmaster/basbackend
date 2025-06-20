using Common.GenericsMethods.GenericResponse;
using Infraestructure.Models;
using MediatR;

namespace Common.GenericsMethods;

public class UpdateCommand<T> : IRequest<Unit> where T : BaseDomainEntity
{
    public T EntityToUpdate { get; }

    public UpdateCommand(T entity)
    {
        EntityToUpdate = entity;
    }
}