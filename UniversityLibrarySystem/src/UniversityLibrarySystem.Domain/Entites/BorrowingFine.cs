using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityLibrarySystem.Domain.Entites;

/// <summary>
/// Represents a fine associated with a borrowing record.
/// </summary>
public class BorrowingFine: BaseEntity
{
    /// <summary>
    /// Gets or sets the ID of the borrowing record to which the fine is associated.
    /// </summary>
    public int BorrowingRecordId {  get; set; }

    /// <summary>
    /// Gets or sets the amount of the fine.
    /// </summary>
    [Column(TypeName = "decimal(18, 2)")]
    public decimal FineAmount { get; set; } 
}