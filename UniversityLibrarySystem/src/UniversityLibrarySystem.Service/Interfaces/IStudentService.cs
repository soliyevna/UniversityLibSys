using UniversityLibrarySystem.Domain.Entites;
using UniversityLibrarySystem.Service.Dtos;

namespace UniversityLibrarySystem.Service.Interfaces;

/// <summary>
/// Interface for the service responsible for student-related operations.
/// </summary>
public interface IStudentService
{
    /// <summary>
    /// Creates a new student asynchronously.
    /// </summary>
    /// <param name="studentCreateDto">The data for creating the student.</param>
    /// <returns>A task representing the asynchronous operation, returning the ID of the created student.</returns>
    public Task<int> CreateStudentAsync(StudentCreateDto studentCreateDto);

    /// <summary>
    /// Retrieves a list of all students asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation, returning a list of all students.</returns>
    public Task<List<Student>> GetAllAsync();

    /// <summary>
    /// Updates an existing student asynchronously.
    /// </summary>
    /// <param name="id">The ID of the student to update.</param>
    /// <param name="student">The updated student data.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task UpdateAsync(int id, Student student); 
}