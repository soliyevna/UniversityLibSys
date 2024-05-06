using Microsoft.AspNetCore.Mvc;
using UniversityLibrarySystem.DataAccess.Interfaces.Common;
using UniversityLibrarySystem.Domain.Entites;
using UniversityLibrarySystem.Service.Dtos;
using UniversityLibrarySystem.Service.Interfaces;

namespace UniversityLibrarySystem.WEB.Controllers.Students;

//[Route("")]
public class StudentController : Controller
{
    private readonly IStudentService _studentService;
    private readonly IUnitOfWork _unitOfWork;

    public StudentController(IStudentService studentService, IUnitOfWork unitOfWork)
    {
        this._studentService = studentService;
        this._unitOfWork = unitOfWork;
    }

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
            if(res == 0)
            {
                return RedirectToAction("Index", "Student");
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

    [HttpGet("update")]
    public async Task<ViewResult> Update(int id)
    {
        var student = await _unitOfWork.StudentRepository.GetById(id);
        ViewBag.studentId = student.Id;
        return View("Update", student);
    }

    [HttpPost("update")]
    [Route("Student/Update")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateStudentInfoAsync(Student student)
    {
        if(student != null)
        {
            await _studentService.UpdateAsync(student.Id, student);
            return RedirectToAction("Index", "Student");
        }
        return await Index();
    }

    [HttpDelete("delete")]
    [Route("Student/Delete")]
    public async Task<IActionResult> DeleteStudentAsync(int id)
    {
        _unitOfWork.StudentRepository.Delete(id);
        await _unitOfWork.SaveAsync();
        return Ok();
    }
}