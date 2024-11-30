using Allup.Application.Services.Abstracts;
using Allup.Application.UI.Services.Abstracts;
using Allup.Application.UI.Services.Implementations;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace Allup.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService, ILanguageService languageService)
        {
            _homeService = homeService;
        }

        public async Task<IActionResult> Index()
        {
            var homeViewModel = await _homeService.GetHomeViewModelAsync();

            return View(homeViewModel);
        }
    }
}
