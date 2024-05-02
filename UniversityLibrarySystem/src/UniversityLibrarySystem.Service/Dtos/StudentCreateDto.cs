using System.ComponentModel.DataAnnotations;

namespace UniversityLibrarySystem.Service.Dtos;

public class StudentCreateDto
{
    /// <summary>
    /// Gets or sets the name of the student.
    /// </summary>
    [Required(ErrorMessage = "Name of the student is required.")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the address of the student.
    /// </summary>
    [Required(ErrorMessage = "Address of the student is required.")]
    [StringLength(100, ErrorMessage = "Address cannot exceed 100 characters.")]
    public string Address { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the email address of the student.
    /// </summary>
    [Required(ErrorMessage = "Email of the student is required.")]
    [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
    public string Email { get; set; } = string.Empty;
}