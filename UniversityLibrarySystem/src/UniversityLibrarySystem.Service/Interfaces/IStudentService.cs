using UniversityLibrarySystem.Domain.Entites;
using UniversityLibrarySystem.Service.Dtos;

namespace UniversityLibrarySystem.Service.Interfaces;

public interface IStudentService
{
    public Task<int> CreateStudentAsync(StudentCreateDto studentCreateDto);
    public Task<List<Student>> GetAllAsync();
}