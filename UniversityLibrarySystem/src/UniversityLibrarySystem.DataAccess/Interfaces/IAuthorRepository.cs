using UniversityLibrarySystem.DataAccess.Interfaces.Common;
using UniversityLibrarySystem.Domain.Entites;

namespace UniversityLibrarySystem.DataAccess.Interfaces;

public interface IAuthorRepository: IBaseRepository<Author>
{
    public Task<List<Author>> GetAllAsync();
}