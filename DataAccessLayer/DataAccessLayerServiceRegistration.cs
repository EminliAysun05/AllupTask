using DataAccessLayer.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class DataAccessLayerServiceRegistration
    {
        public static IServiceCollection AddDalService(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer("Server=RAFETR\\SQLEXPRESS;Database=Testt; Trusted_Connection=True;TrustServerCertificate = true"));

            return services;
        }
    }
}
