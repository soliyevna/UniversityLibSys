namespace UniversityLibrarySystem.Domain.Entites;

/// <summary>
/// Represents an entity to build a many-to-many connection between books and authors.
/// </summary>
public class BookAuthor: BaseEntity
{
    /// <summary>
    /// Gets or sets the ID of the book.
    /// </summary>
    public int BookId {  get; set; }

    /// <summary>
    /// Gets or sets the ID of the book.
    /// </summary>
    public int AuthorId {  get; set; }
}
