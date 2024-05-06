using UniversityLibrarySystem.Service.Dtos;

namespace UniversityLibrarySystem.Service.Interfaces;

public interface IBookService
{
    public Task CreateBookAsync(BookCreateDto bookCreateDto);
}
