namespace UniversityLibrarySystem.DataAccess.Interfaces.Common;

/// <summary>
/// Represents a unit of work interface for managing repositories.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Gets the repository for managing student entities.
    /// </summary>
    public IStudentRepository StudentRepository { get; }

    /// <summary>
    /// Gets the repository for managing book entities.
    /// </summary>
    public IBookRepository BookRepository { get; }

    /// <summary>
	/// Saves entities which are changed their state from <see cref="EntityState.Unchanged"/> to other state from <see cref="EntityState"/>
	/// </summary>
	/// <returns>A Task representing an asynchronous operation.</returns>
    public Task SaveAsync();
}
