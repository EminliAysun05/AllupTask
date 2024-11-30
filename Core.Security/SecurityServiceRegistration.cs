using Academy.AuthenticationService;
using Core.Security.Jwt.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Security;

public static class SecurityServiceRegistration
{
    public static IServiceCollection AddSecurityServices(this IServiceCollection services)
    {
        services.AddScoped<IJwtAuthService, JwtAuthManager>();

        return services;
    }
}
