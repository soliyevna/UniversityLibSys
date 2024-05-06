using UniversityLibrarySystem.DataAccess.Interfaces.Common;
using UniversityLibrarySystem.Domain.Entites;

namespace UniversityLibrarySystem.DataAccess.Interfaces;

public interface IGenreRepository: IBaseRepository<Genre>
{
    public Task<List<Genre>> GetAllAsync();
}
