namespace UniversityLibrarySystem.Domain.Entites;

/// <summary>
/// Represents an entity to build a many-to-many connection between books and genres.
/// </summary>
public class BookGenre: BaseEntity
{
    /// <summary>
    /// Gets or sets the ID of the book.
    /// </summary>
    public int BookId {  get; set; }

    /// <summary>
    /// Gets or sets the ID of the genre of the book .
    /// </summary>
    public int GenreId {  get; set; }
}
