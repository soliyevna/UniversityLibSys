using System.ComponentModel.DataAnnotations;

namespace UniversityLibrarySystem.Domain.Entites;

/// <summary>
/// Represents a base entity for other entities.
/// </summary>
public class BaseEntity
{
    /// <summary>
    /// Gets or sets the unique identifier of the entity.
    /// </summary>
    [Required(ErrorMessage ="The unique identifier is required.")]
    public int Id { get; set; } 
}
