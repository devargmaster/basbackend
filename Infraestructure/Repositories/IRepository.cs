using System.Linq.Expressions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories;

public interface IRepository
{
    Task<IEnumerable<T>> GetAsync<T>() where T : BaseDomainEntity;
    Task<T> GetByIdAsync<T>(int id) where T : BaseDomainEntity;
    Task<IEnumerable<T>> FindAsync<T>(Expression<Func<T, bool>> predicate) where T : BaseDomainEntity;
    Task<T> CreateAsync<T>(T entity) where T : BaseDomainEntity;
    Task<T> UpdateAsync<T>(T entity) where T : BaseDomainEntity;
    Task<T> DeleteAsync<T>(int id) where T : BaseDomainEntity;
    Task<T?> FindWithIncludeAsync<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : BaseDomainEntity;
}