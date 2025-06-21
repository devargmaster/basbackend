using Common.GenericsMethods.GenericResponse;
using Domain.Models;
using MediatR;

namespace Common.GenericsMethods;

public class CreateCommand<T> : IRequest<CreateResponse<T>> where T : BaseDomainEntity
{
    public T EntityToCreate { get; }

    public CreateCommand(T entity)
    {
        EntityToCreate = entity;
    }
}