using System.Linq.Expressions;
using Infraestructure.Contexts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infraestructure.Repositories;

public class SqlRepository : IRepository
{
    private readonly DbContext context;
    private readonly ILogger logger;

    public SqlRepository(IDbContext context, ILogger<SqlRepository> logger)
    {
        this.context = context.GetContext();
        this.logger = logger;
    }
    
    public async Task<IEnumerable<T>> GetAsync<T>() where T : BaseDomainEntity
    {
         try
         {
             var entities = await context.Set<T>().ToListAsync();

             logger.LogInformation($"Entities of type {typeof(T).Name} queried from Sql Server.");

             return entities;
         }
         catch (Exception ex)
         {
             logger.LogError(ex, $"Error retrieving entities of type {typeof(T).Name} with filter.");
             return Enumerable.Empty<T>();
         }
    }

    public async Task<T> GetByIdAsync<T>(int id) where T : BaseDomainEntity
    {
        var entity = await context.Set<T>().FindAsync(id);

        return entity;
    }

    public async Task<IEnumerable<T>> FindAsync<T>(Expression<Func<T, bool>> predicate) where T : BaseDomainEntity
    {
        return await context.Set<T>().Where(predicate).ToListAsync();
    }

    public async Task<T> CreateAsync<T>(T entity) where T : BaseDomainEntity
    {
        context.Set<T>().Add(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> UpdateAsync<T>(T entity) where T : BaseDomainEntity
    {
        try
        {
            var existingEntity = await context.Set<T>().FindAsync(entity.Id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Entity of type {typeof(T).Name} with ID {entity.Id} not found.");
            }

            context.Entry(existingEntity).CurrentValues.SetValues(entity);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Error updating entity of type {typeof(T).Name} with ID {entity.Id}.");
            throw;
        }
        return entity;
    }

    public async Task<T> DeleteAsync<T>(int id) where T : BaseDomainEntity
    {
        var entity = await context.Set<T>().FindAsync(id);
        if (entity != null)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }
        else
        {
            throw new KeyNotFoundException($"Entity of type {typeof(T).Name} with id {id} not found.");
        }
        return entity;
    }
}