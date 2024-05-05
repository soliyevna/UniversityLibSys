using UniversityLibrarySystem.DataAccess.Configurations;
using UniversityLibrarySystem.DataAccess.Interfaces;
using UniversityLibrarySystem.DataAccess.Interfaces.Common;
using UniversityLibrarySystem.DataAccess.Repositories;
using UniversityLibrarySystem.DataAccess.Repositories.Common;
using UniversityLibrarySystem.Service.Interfaces;
using UniversityLibrarySystem.Service.Services;

namespace UniversityLibrarySystem.WEB.Extensions;

/// <summary>
/// Provides extension methods for configuring services in the <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds data access services to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> instance to which the services are added.</param>
    /// <param name="configuration">The configuration from which to retrieve the connection string.</param>
    /// <exception cref="ArgumentNullException">Thrown if the connection string is not defined in the configuration.</exception>
    public static void AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("UniversityLibrarySystemDb")
            ?? throw new ArgumentNullException(nameof(connectionString), "Connection string is not defined");
        
        services.AddDataContext(connectionString);
        services.AddScoped<IUnitOfWork,  UnitOfWork>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IStudentService, StudentService>();
        services.AddAutoMapper(typeof(MappingConfiguration));
    }
}