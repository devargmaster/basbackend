using Domain.Models;

namespace Common.GenericsMethods.GenericResponse;

public class CreateResponse<T> where T : BaseDomainEntity
{
    public T Entity { get; }

    public CreateResponse(T entity)
    {
        Entity = entity;
    }
}