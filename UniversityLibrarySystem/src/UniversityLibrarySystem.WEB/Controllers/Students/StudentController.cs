using Microsoft.AspNetCore.Mvc;

namespace UniversityLibrarySystem.WEB.Controllers.Students;

[Route("admin/students")]
public class StudentController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
