using Microsoft.EntityFrameworkCore;
using UniversityLibrarySystem.DataAccess.DbContexts;
using UniversityLibrarySystem.DataAccess.Interfaces;
using UniversityLibrarySystem.DataAccess.Interfaces.Common;

namespace UniversityLibrarySystem.DataAccess.Repositories.Common;

/// <summary>
/// Represents a concrete implementation of the <see cref="IUnitOfWork"/> interface.
/// </summary>
public class UnitOfWork: IUnitOfWork, IDisposable
{
    private readonly DataContext _dataContext;
    private bool disposed = false;

    /// <summary>
    /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
    /// </summary>
    /// <param name="dbContext">The <see cref="DataContext"/> instance to be used.</param>
    public UnitOfWork(DataContext dataContext)
    {
        this._dataContext = dataContext;
        this.StudentRepository = new StudentRepository(_dataContext);
        this.BookRepository = new BookRepository(_dataContext);
        this.PublisherRepository = new PublisherRepository(_dataContext);
        this.GenreRepository = new GenreRepository(_dataContext);
    }

    /// <inheritdoc/>
    public IStudentRepository StudentRepository { get; }

    /// <inheritdoc/>
    public IBookRepository BookRepository { get; }

    public IPublisherRepository PublisherRepository { get; }
    public IGenreRepository GenreRepository { get; }    

    /// <inheritdoc/>
    public async Task SaveAsync()
    {
        await _dataContext.SaveChangesAsync();
    }

    /// <inheritdoc/>
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                _dataContext.Dispose();
            }

            disposed = true;
        }
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
