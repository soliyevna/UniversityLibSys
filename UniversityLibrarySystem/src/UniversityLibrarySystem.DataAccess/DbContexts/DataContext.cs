using Microsoft.EntityFrameworkCore;
using System;
using System.Xml;
using UniversityLibrarySystem.DataAccess.Configurations;
using UniversityLibrarySystem.Domain.Entites;

namespace UniversityLibrarySystem.DataAccess.DbContexts;

public class DataContext: DbContext
{
    /// <summary>s
    /// Gets or sets the DbSet for managing author entities in the database.
    /// </summary>
    public DbSet<Author> Authors { get; set; }

    /// <summary>s
    /// Gets or sets the DbSet for managing book entities in the database.
    /// </summary>
    public DbSet<Book> Books { get; set; }

    /// <summary>s
    /// Gets or sets the DbSet for managing book author entities in the database.
    /// </summary>
    public DbSet<BookAuthor> BookAuthors { get; set; }

    /// <summary>s
    /// Gets or sets the DbSet for managing book genre entities in the database.
    /// </summary>
    public DbSet<BookGenre> BookGenres { get; set; }

    /// <summary>s
    /// Gets or sets the DbSet for managing borrowing fine entities in the database.
    /// </summary>
    public DbSet<BorrowingFine> BorrowingFines { get; set; }

    /// <summary>s
    /// Gets or sets the DbSet for managing borrowing record entities in the database.
    /// </summary>
    public DbSet<BorrowingRecord> BorrowingRecords { get; set; }

    /// <summary>s
    /// Gets or sets the DbSet for managing genre entities in the database.
    /// </summary>
    public DbSet<Genre> Genres { get; set; }

    /// <summary>s
    /// Gets or sets the DbSet for managing publisher entities in the database.
    /// </summary>
    public DbSet<Publisher> Publishers { get; set; }

    /// <summary>s
    /// Gets or sets the DbSet for managing student entities in the database.
    /// </summary>
    public DbSet<Student> Students { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DataContext"/> class with the provided options.
    /// </summary>
    /// <param name="options">The options for configuring the database context.</param>
    public DataContext(DbContextOptions<DataContext> options)
            : base(options)
    {

    }

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new GenreConfiguration());
    }

    /// <inheritdoc/>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("UniversityLibrarySystem");
        }
    }

    /// <inheritdoc/>
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
        configurationBuilder.Properties<DateOnly>()
            .HaveConversion<DateOnlyConverter>();
    }
}