using Microsoft.EntityFrameworkCore;
using UniversityLibrarySystem.DataAccess.DbContexts;
using UniversityLibrarySystem.DataAccess.Interfaces;
using UniversityLibrarySystem.DataAccess.Repositories.Common;
using UniversityLibrarySystem.Domain.Entites;

namespace UniversityLibrarySystem.DataAccess.Repositories;

public class AuthorRepository: BaseRepository<Author>, IAuthorRepository
{
    public AuthorRepository(DataContext dataContext): base(dataContext)
    {
    }
    public async Task<List<Author>> GetAllAsync()
    {
        var authors = await Collection.AsNoTracking().OrderBy(a => a.Name).ToListAsync();
        return authors;
    }
}
