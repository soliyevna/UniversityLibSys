using System.ComponentModel.DataAnnotations;

namespace UniversityLibrarySystem.Domain.Entites;

/// <summary>
/// Represents an author entity.
/// </summary>
public class Author: BaseEntity
{
    /// <summary>
    /// Gets or sets the name of the author.
    /// </summary>
    [Required(ErrorMessage = "Name of the author is required.")]
    public string Name {  get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the biography of the author.
    /// </summary>
    [StringLength(300, ErrorMessage = "Biography cannot exceed 300 characters.")]
    public string Biography {  get; set; } = string.Empty;
}