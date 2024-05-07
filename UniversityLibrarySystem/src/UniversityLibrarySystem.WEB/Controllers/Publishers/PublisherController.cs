using Microsoft.AspNetCore.Mvc;
using UniversityLibrarySystem.DataAccess.Interfaces.Common;
using UniversityLibrarySystem.Domain.Entites;

namespace UniversityLibrarySystem.WEB.Controllers.Publishers;

public class PublisherController : Controller
{
    private IUnitOfWork _unitOfWork;

    public PublisherController(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;    
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("createPublisher")]
    public ViewResult Create()
    {
        return View("Create");
    }

    [HttpPost("createPublisher")]
    [Route("Publisher/Create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreatePublisherAsync(Publisher publisher)
    {
        if (ModelState.IsValid)
        {
            int res = _unitOfWork.PublisherRepository.Create(publisher);
            await _unitOfWork.SaveAsync();
            return Create();
        }
        return Create();
    }
}
