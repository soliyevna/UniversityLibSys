using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UniversityLibrarySystem.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace UniversityLibrarySystem.DataAccess.Configurations;

/// <summary>
/// Contains method to inject DbContext
/// </summary>
public static class DbContextConfiguration
{
    /// <summary>
	/// Injects DbContext with given connection string.
	/// </summary>
	/// <param name="services">Instance of <see cref="IServiceCollection"/> used to extend its functionality</param>
	/// <param name="connectionString">Connection string of SqlServer database</param>
    public static void AddDataContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<DataContext>(
            options => options.UseSqlServer(connectionString,
            builder =>
            {
                builder.MigrationsAssembly("UniversityLibrarySystem.DataAccess");
            }));
    }
}