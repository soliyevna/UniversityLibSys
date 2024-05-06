using Microsoft.AspNetCore.Mvc;
using UniversityLibrarySystem.DataAccess.Interfaces.Common;
using UniversityLibrarySystem.Service.Dtos;
using UniversityLibrarySystem.Service.Interfaces;

namespace UniversityLibrarySystem.WEB.Controllers.Books;

public class BookController : Controller
{
    private readonly IBookService _bookService;
    private readonly IUnitOfWork _unitOfWork;

    public BookController(IBookService bookService, IUnitOfWork unitOfWork)
    {
        this._bookService = bookService;
        this._unitOfWork = unitOfWork;
    }
    public IActionResult Index()
    {
        return View();
    }

    /// <summary>
    /// Displays the view for creating a new book.
    /// </summary>
    /// <returns>The view for creating a new student.</returns>

    [HttpGet("createBook")]
    public async Task<ViewResult> Create()
    {
        var genresList = await _unitOfWork.GenreRepository.GetAllAsync();
        var publishersList = await _unitOfWork.PublisherRepository.GetAllAsync();
        ViewBag.genresList = genresList;
        ViewBag.publishersList = publishersList;
        return View("Create");
    }

    /// <summary>
    /// Handles the submission of a new book creation form.
    /// </summary>
    /// <param name="studentCreateDto">The data for creating a new book.</param>
    /// <returns>A redirect to the book index page if successful, otherwise the create view.</returns>
    [HttpPost("createBook")]
    [Route("Book/Create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateBookAsync(BookCreateDto bookCreateDto)
    {
        if (ModelState.IsValid)
        {
            await _bookService.CreateBookAsync(bookCreateDto);
            return await Create();
        }
        return await Create();
    }
}
