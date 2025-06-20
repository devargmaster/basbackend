using Infraestructure.Models;

namespace Common.GenericsMethods.GenericResponse;

public class GetByIdResponse<T> where T : BaseDomainEntity
{
    public T Entity { get; }
    public GetByIdResponse(T entity)
    {
        Entity = entity;
    }
}