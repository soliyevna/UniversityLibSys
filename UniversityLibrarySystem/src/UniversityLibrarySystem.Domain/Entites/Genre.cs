using System.ComponentModel.DataAnnotations;

namespace UniversityLibrarySystem.Domain.Entites;

/// <summary>
/// Represents a genre entity of a book.
/// </summary>
public class Genre: BaseEntity
{
    /// <summary>
    /// Gets or sets the Name of the genre.
    /// </summary>
    [Required(ErrorMessage = "Name of the genre is required.")]
    public string Name {  get; set; } = string.Empty;
}
