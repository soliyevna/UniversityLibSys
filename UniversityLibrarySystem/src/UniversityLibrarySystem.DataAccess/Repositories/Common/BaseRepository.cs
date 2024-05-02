using Microsoft.EntityFrameworkCore;
using UniversityLibrarySystem.DataAccess.DbContexts;
using UniversityLibrarySystem.DataAccess.Interfaces.Common;
using UniversityLibrarySystem.Domain.Entites;

namespace UniversityLibrarySystem.DataAccess.Repositories.Common;

/// <summary>
/// Represents a base repository class for CRUD operations on entities of type TEntity.
/// </summary>
/// <typeparam name="TEntity">The type of entity.</typeparam>
public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly DataContext _dataContext;

    protected DbSet<TEntity> Collection { get; init; }

    protected BaseRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
        Collection = dataContext.Set<TEntity>();
    }

    /// <inheritdoc/>
    public int Create(TEntity entity)
    {
        Collection.Add(entity);
        return entity.Id;
    }

    /// <inheritdoc/>
    public void Delete(int id)
    {
        var entity = Collection.Find(id);
        if (entity is not null)
        {
            Collection.Remove(entity);
        }
    }

    /// <inheritdoc/>
    public async Task<TEntity?> GetById(int id)
    {
        var entity = await Collection.FindAsync(id);
        return entity;
    }

    /// <inheritdoc/>
    public void Update(TEntity entity)
    {
        Collection.Update(entity);
    }
}