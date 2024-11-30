using Academy.Persistence.Context;
using Academy.Persistence.Repositories.Abstraction;
using Academy.Persistence.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Academy.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("AcademyDbConnection"));
        });

        services.AddScoped<IStudentRepository, StudentRepository>();

        return services;
    }
}
