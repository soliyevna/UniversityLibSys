using UniversityLibrarySystem.Service.Dtos;

namespace UniversityLibrarySystem.Service.Interfaces;

internal interface IStudentService
{
    public Task<int> CreateStudentAsync(StudentCreateDto studentCreateDto);
}