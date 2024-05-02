using UniversityLibrarySystem.Domain.Entites;

namespace UniversityLibrarySystem.DataAccess.Interfaces.Common;

/// <summary>
/// Represents a base repository interface for CRUD operations on entities of type TEntity.
/// </summary>
/// <typeparam name="TEntity">The type of entity.</typeparam>
public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    /// <summary>
    /// Creates a new entity in the repository.
    /// </summary>
    /// <param name="entity">The entity to create.</param>
    /// <returns>The ID of the newly created entity.</returns>
    public int Create(TEntity entity);

    /// <summary>
    /// Deletes an entity from the repository based on its ID.
    /// </summary>
    /// <param name="id">The ID of the entity to delete.</param>
    public void Delete(int id);

    /// <summary>
    /// Updates an existing entity in the repository.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    public void Update(TEntity entity);

    /// <summary>
    /// Retrieves an entity from the repository based on its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the entity to retrieve.</param>
    /// <returns>
    /// A task representing the asynchronous operation. The task result contains
    /// the entity if found, otherwise null.
    /// </returns>
    public Task<TEntity?> GetById(int id);
}