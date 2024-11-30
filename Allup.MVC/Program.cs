using Allup.Domain.Entities;
using Allup.Persistence;
using Allup.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Allup.Application;
using Microsoft.Extensions.Options;
using Allup.Application.UI.Services.Implementations;

namespace Allup.MVC
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
            builder.Services.AddMvc().AddViewLocalization();

            builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 4;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            builder.Services.AddHttpClient<ExternalApiService>();
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddApplicationServices();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                //Old way
                //var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();
                //var appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                //var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                //var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                //var dataInitializer = new DataInitializer(userManager, roleManager, appDbContext, config);

                //Asiman style
                var dataInitializer = scope.ServiceProvider.GetService<DataInitializer>();
                await dataInitializer!.SeedDataAsync();
            }

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            var locOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();

            app.UseRequestLocalization(locOptions!.Value);

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            await app.RunAsync();
        }
    }
}
