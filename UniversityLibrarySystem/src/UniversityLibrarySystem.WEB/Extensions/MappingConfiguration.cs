using AutoMapper;
using UniversityLibrarySystem.Domain.Entites;
using UniversityLibrarySystem.Service.Dtos;

namespace UniversityLibrarySystem.WEB.Extensions;

public class MappingConfiguration: Profile
{
    public MappingConfiguration()
    {
        CreateMap<Student, StudentCreateDto>().ReverseMap();
    }
}