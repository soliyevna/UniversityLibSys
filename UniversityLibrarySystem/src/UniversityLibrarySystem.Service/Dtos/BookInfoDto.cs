namespace UniversityLibrarySystem.Service.Dtos;

public class BookInfoDto
{
    public string AutherName {  get; set; } = string.Empty;
    public string PublisherName {  get; set; } = string.Empty;
    /// <summary>
    /// Gets or sets the title of the book.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the publication date of the book.
    /// </summary>
    public DateTime PublicationDate { get; set; }

    /// <summary>
    /// Gets or sets the ID of the publisher that published the book.
    /// </summary>
    public int PublisherId { get; set; }

    public List<string> Genres { get; set; }
}
