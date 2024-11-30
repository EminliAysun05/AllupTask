using Allup.Application.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace Allup.MVC.Controllers
{
    public class CompareController : LocalizerController
    {
        private readonly ICompareService _compareService;
        public CompareController(ILanguageService languageService, ICompareService compareService) : base(languageService)
        {
            _compareService = compareService;
        }

        public async Task<IActionResult> Index()
        {
            var compareItems = await _compareService.GetCompareItemsAsync(await GetLanguageAsync());

            return View(compareItems);
        }

        public async Task<IActionResult> AddToCompareList(int productId)
        {
            var count = await _compareService.AddToCompareListAsync(productId);

            return Json(new { count });
        }

        public async Task<IActionResult> RemoveFromCompareList(int productId)
        {
            var compareItems = await _compareService.RemoveFromCompareListAsync(productId, await GetLanguageAsync());

            return PartialView("_CompareTablePartial", compareItems);
        }
    }
}
