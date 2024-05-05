using Microsoft.AspNetCore.Mvc;
using UniversityLibrarySystem.Domain.Entites;
using UniversityLibrarySystem.Service.Dtos;
using UniversityLibrarySystem.Service.Interfaces;

namespace UniversityLibrarySystem.WEB.Controllers.Students;

//[Route("")]
public class StudentController : Controller
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        this._studentService = studentService;
    }

    /*public IActionResult Index()
    {
        return View();
    }*/

    [HttpGet("create")]
    public ViewResult Create()
    {
        return View("Create");
    }

    [HttpPost("create")]
    [Route("Student/Create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateStudentAsync(StudentCreateDto studentCreateDto)
    {
        if(ModelState.IsValid)
        {
            int res = await _studentService.CreateStudentAsync(studentCreateDto);
            if(res > 0)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Create();
            }
        }
        return Create();
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        List<Student> students = await _studentService.GetAllAsync();
        return View(students);
    }
}
