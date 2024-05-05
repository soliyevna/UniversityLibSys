using UniversityLibrarySystem.DataAccess.Interfaces.Common;
using UniversityLibrarySystem.Domain.Entites;

namespace UniversityLibrarySystem.DataAccess.Interfaces;

/// <summary>
/// Represents a repository for performing CRUD operations specific to the <see cref="Student"/> entity.
/// </summary>
public interface IStudentRepository: IBaseRepository<Student>
{
    public Task<List<Student>> GetAllAsync();
}