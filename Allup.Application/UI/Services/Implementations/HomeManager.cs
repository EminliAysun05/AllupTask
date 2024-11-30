using Allup.Application.Services.Abstracts;
using Allup.Application.UI.Services.Abstracts;
using Allup.Application.UI.ViewModels;
using Allup.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Allup.Application.UI.Services.Implementations;

public class HomeManager : IHomeService
{
    private readonly ICategoryService _categoryService;
    private readonly IProductService _productService;
    private readonly ICookieService _cookieService;

    public HomeManager(ICategoryService categoryService, IProductService productService, ICookieService cookieService)
    {
        _categoryService = categoryService;
        _productService = productService;
        _cookieService = cookieService;
    }

    public async Task<HomeViewModel> GetHomeViewModelAsync()
    {
        var language = await _cookieService.GetLanguageAsync();
        var categories = await _categoryService.GetAllAsync(include: x => x
                             .Include(y => y.CategoryTranslations!.Where(z => z.LanguageId == language.Id)));
        var products = await _productService.GetAllAsync(include: x => x
                         .Include(y => y.ProductTranslations!.Where(z => z.LanguageId == language.Id)));

        var homeViewModel = new HomeViewModel
        {
            Categories = categories,
            Products = products
        };

        return homeViewModel;
    }
}
