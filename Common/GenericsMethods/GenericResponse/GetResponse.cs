using Domain.Models;

namespace Common.GenericsMethods.GenericResponse;

public class GetResponse<T> where T : BaseDomainEntity
{
    public IEnumerable<T> Data { get; }

    public GetResponse(IEnumerable<T> entities)
    {
        Data = entities;
    }
}