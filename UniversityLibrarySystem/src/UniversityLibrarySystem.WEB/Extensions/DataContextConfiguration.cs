using Microsoft.EntityFrameworkCore;
using UniversityLibrarySystem.DataAccess.DbContexts;


namespace UniversityLibrarySystem.WEB.Extensions;

/// <summary>
/// Provides extension methods for configuring data context.
/// </summary>
public static class DataContextConfiguration
{
    /// <summary>
    /// Migrates the database associated with the specified <typeparamref name="TContext"/> to the latest version.
    /// </summary>
    /// <typeparam name="TContext">The type of the database context.</typeparam>
    /// <param name="builder">The <see cref="IApplicationBuilder"/> instance.</param>
    /// <returns>The <see cref="IApplicationBuilder"/> instance.</returns>
    public static IApplicationBuilder MigrateDatabaseToLatest<TContext>(this IApplicationBuilder builder) where TContext : DbContext
    {
        using var scope = builder.ApplicationServices.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();

        dbContext.Database.Migrate();

        return builder;
    }
}