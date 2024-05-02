using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace UniversityLibrarySystem.DataAccess.Configurations;

/// <summary>
/// Converts between <see cref="DateOnly"/> and <see cref="DateTime"/>.
/// </summary>
public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DateOnlyConverter"/> class.
    /// </summary>
    public DateOnlyConverter() : base(
        dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
        dateTime => DateOnly.FromDateTime(dateTime))
    { }
}