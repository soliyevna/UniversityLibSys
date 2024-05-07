using Microsoft.EntityFrameworkCore;
using UniversityLibrarySystem.DataAccess.DbContexts;
using UniversityLibrarySystem.DataAccess.Interfaces;
using UniversityLibrarySystem.DataAccess.Repositories.Common;
using UniversityLibrarySystem.Domain.Entites;

namespace UniversityLibrarySystem.DataAccess.Repositories;

/// <summary>
/// Represents a repository for performing CRUD operations specific to the <see cref="Book"/> entity.
/// </summary>
public class BookRepository: BaseRepository<Book>, IBookRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BookRepository"/> class with the provided database context.
    /// </summary>
    /// <param name="context">The database context associated with the repository.</param>
    public BookRepository(DataContext dataContext): base(dataContext)
    {
        
    }

    public async Task<List<Book>> GetAllAsync()
    {
        var books = await Collection.AsNoTracking().ToListAsync();
        return books;
    }
}
