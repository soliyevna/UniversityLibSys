using UniversityLibrarySystem.DataAccess.Interfaces.Common;
using UniversityLibrarySystem.Domain.Entites;
using UniversityLibrarySystem.Service.Dtos;
using UniversityLibrarySystem.Service.Interfaces;

namespace UniversityLibrarySystem.Service.Services;

public class BookService : IBookService
{
    private readonly IUnitOfWork _unitOfWork;

    public BookService(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }
    public async Task CreateBookAsync(BookCreateDto bookCreateDto)
    {
        Book book = new()
        {
            Title = bookCreateDto.Title,
            PublicationDate = bookCreateDto.PublicationDate,
        };

        var doesAnyPublisherExistWithThisName = await _unitOfWork.PublisherRepository.DoesExist(book.Title);
       
        bool doesExist = doesAnyPublisherExistWithThisName.Item1;
        int publisherId = doesAnyPublisherExistWithThisName.Item2;
        
        if(doesExist)
        {
            book.PublisherId = publisherId;
        }
        else
        {
            Publisher publisher = new()
            {
                Name = bookCreateDto.PublisherName
            };
            _unitOfWork.PublisherRepository.Create(publisher);
            book.PublisherId = publisher.Id;
        }

        _unitOfWork.BookRepository.Create(book);
        await _unitOfWork.SaveAsync();
    }
}
