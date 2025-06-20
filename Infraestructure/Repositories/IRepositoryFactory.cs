using Infraestructure.Models;

namespace Infraestructure.Repositories;

public interface IRepositoryFactory
{
    IRepository CreateRepository<T>() where T : BaseDomainEntity;
}