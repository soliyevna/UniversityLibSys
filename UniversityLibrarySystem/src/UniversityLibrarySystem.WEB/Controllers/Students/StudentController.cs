using Microsoft.AspNetCore.Mvc;
using UniversityLibrarySystem.DataAccess.Interfaces.Common;
using UniversityLibrarySystem.Domain.Entites;
using UniversityLibrarySystem.Service.Dtos;
using UniversityLibrarySystem.Service.Interfaces;

namespace UniversityLibrarySystem.WEB.Controllers.Students;

/// <summary>
/// Controller for managing student-related actions.
/// </summary>
public class StudentController : Controller
{
    private readonly IStudentService _studentService;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Initializes a new instance of the <see cref="StudentController"/> class.
    /// </summary>
    /// <param name="studentService">The student service.</param>
    /// <param name="unitOfWork">The unit of work.</param>
    public StudentController(IStudentService studentService, IUnitOfWork unitOfWork)
    {
        this._studentService = studentService;
        this._unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Displays the view for creating a new student.
    /// </summary>
    /// <returns>The view for creating a new student.</returns>

    [HttpGet("create")]
    public ViewResult Create()
    {
        return View("Create");
    }

    /// <summary>
    /// Handles the submission of a new student creation form.
    /// </summary>
    /// <param name="studentCreateDto">The data for creating a new student.</param>
    /// <returns>A redirect to the student index page if successful, otherwise the create view.</returns>
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

    /// <summary>
    /// Displays the index view with a list of all students.
    /// </summary>
    /// <returns>The index view with a list of all students.</returns>
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        List<Student> students = await _studentService.GetAllAsync();
        return View(students);
    }

    /// <summary>
    /// Displays the view for updating a specific student.
    /// </summary>
    /// <param name="id">The ID of the student to update.</param>
    /// <returns>The view for updating the specified student.</returns>
    [HttpGet("update")]
    public async Task<ViewResult> Update(int id)
    {
        var student = await _unitOfWork.StudentRepository.GetById(id);
        ViewBag.studentId = student.Id;
        return View("Update", student);
    }

    /// <summary>
    /// Handles the submission of an updated student information form.
    /// </summary>
    /// <param name="student">The updated student information.</param>
    /// <returns>A redirect to the student index page if successful, otherwise the index view.</returns>
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

    /// <summary>
    /// Deletes a student with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the student to delete.</param>
    /// <returns>An OK result.</returns>
    [HttpDelete("delete")]
    [Route("Student/Delete")]
    public async Task<IActionResult> DeleteStudentAsync(int id)
    {
        _unitOfWork.StudentRepository.Delete(id);
        await _unitOfWork.SaveAsync();
        return Ok();
    }
}