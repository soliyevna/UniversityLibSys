using AutoMapper;
using UniversityLibrarySystem.Domain.Entites;
using UniversityLibrarySystem.Service.Dtos;

namespace UniversityLibrarySystem.WEB.Extensions;

/// <summary>
/// Configuration profile for AutoMapper mappings between entities and DTOs.
/// </summary>
public class MappingConfiguration: Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MappingConfiguration"/> class.
    /// </summary>
    public MappingConfiguration()
    {
        CreateMap<Student, StudentCreateDto>().ReverseMap();
    }
}