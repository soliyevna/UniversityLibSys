using Microsoft.AspNetCore.Mvc;
using UniversityLibrarySystem.DataAccess.Interfaces.Common;
using UniversityLibrarySystem.Domain.Entites;
using UniversityLibrarySystem.Service.Dtos;

namespace UniversityLibrarySystem.WEB.Controllers.Authors;

public class AuthorController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public AuthorController(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork; 
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("createAuthor")]
    public ViewResult Create()
    {
        return View("Create");
    }

    [HttpPost("createAuthor")]
    [Route("Author/Create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateAuthorAsync(Author author)
    {
        if (ModelState.IsValid)
        {
            int res = _unitOfWork.AuthorRepository.Create(author);
            await _unitOfWork.SaveAsync();
            return Create();
        }
        return Create();
    }
}
