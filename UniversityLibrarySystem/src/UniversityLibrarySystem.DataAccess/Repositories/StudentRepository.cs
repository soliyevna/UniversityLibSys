using UniversityLibrarySystem.DataAccess.DbContexts;
using UniversityLibrarySystem.DataAccess.Interfaces;
using UniversityLibrarySystem.DataAccess.Repositories.Common;
using UniversityLibrarySystem.Domain.Entites;

namespace UniversityLibrarySystem.DataAccess.Repositories;

/// <summary>
/// Represents a repository for performing CRUD operations specific to the <see cref="Student"/> entity.
/// </summary>
public class StudentRepository: BaseRepository<Student>, IStudentRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StudentRepository"/> class with the provided database context.
    /// </summary>
    /// <param name="context">The database context associated with the repository.</param>
    public StudentRepository(DataContext dataContext): base(dataContext)
    {
        
    }
}