using System.ComponentModel.DataAnnotations;

namespace UniversityLibrarySystem.Service.Dtos;

public class BookCreateDto
{
    /// <summary>
    /// Gets or sets the title of the book.
    /// </summary>
    [Required(ErrorMessage = "Title of the book is required.")]
    [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the publication date of the book.
    /// </summary>
    public DateTime PublicationDate { get; set; }

    /// <summary>
    /// Gets or sets the name of the publisher that published the book.
    /// </summary>
    public int PublisherId { get; set; }
    public int AutherId {  get; set; }
    public List<int> Genres { get; set; }
    public string PublisherName { get; set; } = string.Empty;
}