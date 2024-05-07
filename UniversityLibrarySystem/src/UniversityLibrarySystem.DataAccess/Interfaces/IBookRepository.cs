using UniversityLibrarySystem.DataAccess.Interfaces.Common;
using UniversityLibrarySystem.Domain.Entites;

namespace UniversityLibrarySystem.DataAccess.Interfaces;

/// <summary>
/// Represents a repository for performing CRUD operations specific to the <see cref="Book"/> entity.
/// </summary>
public interface IBookRepository: IBaseRepository<Book>
{
    public Task<List<Book>> GetAllAsync();
}
