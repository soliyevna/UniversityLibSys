using AutoMapper;
using UniversityLibrarySystem.DataAccess.Interfaces.Common;
using UniversityLibrarySystem.Domain.Entites;
using UniversityLibrarySystem.Service.Dtos;
using UniversityLibrarySystem.Service.Interfaces;

namespace UniversityLibrarySystem.Service.Services;

public class StudentService : IStudentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        this._mapper = mapper;
    }
    public async Task<int> CreateStudentAsync(StudentCreateDto studentCreateDto)
    {
        Student student = _mapper.Map<Student>(studentCreateDto);   
        var res = _unitOfWork.StudentRepository.Create(student);
        await _unitOfWork.SaveAsync();
        return res;
    }

    public Task<List<Student>> GetAllAsync()
    {
        var res = _unitOfWork.StudentRepository.GetAllAsync();
        return res;
    }

    public async Task UpdateAsync(int id, Student student)
    {
        _unitOfWork.StudentRepository.Update(student);
        await _unitOfWork.SaveAsync();
    }
}