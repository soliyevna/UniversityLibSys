namespace UniversityLibrarySystem.Domain.Entites;

/// <summary>
/// Represents a borrowing record entity.
/// </summary>
public class BorrowingRecord: BaseEntity
{
    /// <summary>
    /// Gets or sets the ID of the book that was borrowed.
    /// </summary>
    public int BookId {  get; set; }

    /// <summary>
    /// Gets or sets the ID of the student who borrowed the book.
    /// </summary>
    public int StudentId {  get; set; }

    /// <summary>
    /// Gets or sets the date when the book was borrowed.
    /// </summary>
    public DateTime BorrowingDate { get; set; }

    /// <summary>
    /// Gets or sets the date when the book is expected to be returned.
    /// </summary>
    public DateTime ReturnDate { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the borrowing record has a fine associated with it.
    /// </summary>
    public bool HasFine { get; set; } = false;
}
