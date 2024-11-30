using Academy.Application.Services.StudentService;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Academy.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<IStudentService, StudentManager>();

        return services;
    }
}
