using System.ComponentModel.DataAnnotations;

namespace UniversityLibrarySystem.Domain.Entites;

/// <summary>
/// Represents a publisher entity.
/// </summary>
public class Publisher: BaseEntity
{
    /// <summary>
    /// Gets or sets the name of the publisher.
    /// </summary>
    [Required(ErrorMessage = "Name of the publisher is required.")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    public string Name {  get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the address of the publisher.
    /// </summary>
    [Required(ErrorMessage = "Address of the publisher is required.")]
    [StringLength(100, ErrorMessage = "Address cannot exceed 100 characters.")]
    public string Address { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the contact information of the publisher.
    /// </summary>
    [Required(ErrorMessage = "Contact information of the publisher is required.")]
    [StringLength(100, ErrorMessage = "Contact information cannot exceed 100 characters.")]
    public string ContactInformation { get; set; } = string.Empty ;
}