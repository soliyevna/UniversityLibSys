using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Text.Json;
using UniversityLibrarySystem.Domain.Entites;

namespace UniversityLibrarySystem.DataAccess.Configurations;

/// <summary>
/// Represents migration configurations of <see cref="Genre"/>
/// </summary>
public class GenreConfiguration: IEntityTypeConfiguration<Genre>
{
    #region Genres Data
    private const string Genres = @"
    [
      {
        ""Name"": ""Romance""
      },
      {
        ""Name"": ""Mystery""
      },
      {
        ""Name"": ""Thriller""
      },
      {
        ""Name"": ""Fantasy""
      },
      {
        ""Name"": ""Science Fiction""
      },
      {
        ""Name"": ""Horror""
      },
      {
        ""Name"": ""Adventure""
      },
      {
        ""Name"": ""Historical Fiction""
      },
      {
        ""Name"": ""Biography/Autobiography""
      },
      {
        ""Name"": ""Dystopian""
      },
      {
        ""Name"": ""Comedy""
      },
      {
        ""Name"": ""Young Adult""
      },
      {
        ""Name"": ""Historical Romance""
      },
      {
        ""Name"": ""Erotica""
      },
      {
        ""Name"": ""Non-fiction""
      }
    ]";
    #endregion

    /// <summary>
    /// Applies set of configuration over <see cref="Genre"/> entity
    /// </summary>
    /// <param name="builder">Instance of <see cref="EntityTypeBuilder"/> to configure given entity</param>
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.HasData(GetGenres(Genres));
    }

    private static Genre[] GetGenres(string genresJson)
    {
        var genres = JsonSerializer.Deserialize<Genre[]>(genresJson)
            ?? throw new InvalidDataException($"Could not get set of genres {nameof(genresJson)}.");

        for(int i = 0; i < genres.LongLength; i++)
        {
            genres[i].Id = i + 1;
        }

        return genres;
    }
}
