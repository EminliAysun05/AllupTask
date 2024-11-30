using Allup.Application.Services.Abstracts;
using Allup.Application.Services.Implementations;
using Allup.Application.UI.Services.Abstracts;
using Allup.Application.UI.Services.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Reflection;

namespace Allup.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.Configure<RequestLocalizationOptions>(
           options =>
           {
               var supportedCultures = new List<CultureInfo>
                   {
                        new CultureInfo("en-US"),
                        new CultureInfo("az"),
                   };

               options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");

               options.SupportedCultures = supportedCultures;
               options.SupportedUICultures = supportedCultures;

           });

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<ILanguageService, LanguageManager>();
        services.AddScoped<ICurrencyService, CurrencyManager>();
        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<IProductService, ProductManager>();
        services.AddScoped<IHomeService, HomeManager>();
        services.AddScoped(typeof(ICrudService<,,>), typeof(CrudManager<,,>));
        services.AddScoped<ICompareService, CompareManager>();
        services.AddScoped<ICookieService, CookieManager>();
        services.AddScoped<IWishlistService, WishlistManager>();
        services.AddScoped<IBasketService, BasketManager>();
        services.AddScoped<IBasketUiService, BasketUiService>();
        services.AddScoped<IWishlistUiService, WishlistUiManager>();

        services.AddSingleton<StringLocalizerService>();

        return services;
    }
}
