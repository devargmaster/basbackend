using Common.GenericsMethods.GenericResponse;
using Domain.Models;
using MediatR;

namespace Common.GenericsMethods.Queries;

public class GetQuery<T> : IRequest<GetResponse<T>> where T: BaseDomainEntity
{
}