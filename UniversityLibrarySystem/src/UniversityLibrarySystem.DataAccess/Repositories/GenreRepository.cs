using Microsoft.EntityFrameworkCore;
using UniversityLibrarySystem.DataAccess.DbContexts;
using UniversityLibrarySystem.DataAccess.Interfaces;
using UniversityLibrarySystem.DataAccess.Interfaces.Common;
using UniversityLibrarySystem.DataAccess.Repositories.Common;
using UniversityLibrarySystem.Domain.Entites;

namespace UniversityLibrarySystem.DataAccess.Repositories;

public class GenreRepository: BaseRepository<Genre>, IGenreRepository
{
    public GenreRepository(DataContext dataContext):base(dataContext)
    {
    }

    public async Task<List<Genre>> GetAllAsync()
    {
        var res = await Collection.AsNoTracking().ToListAsync();
        return res;
    }
}
