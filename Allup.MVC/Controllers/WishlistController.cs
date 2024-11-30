using Allup.Application.Services.Abstracts;
using Allup.Application.UI.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Allup.MVC.Controllers
{
    public class WishlistController : Controller
    {
        private readonly IWishlistUiService _wishlistUiService;

        public WishlistController(IWishlistUiService wishlistUiService)
        {
            _wishlistUiService = wishlistUiService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _wishlistUiService.GetWishlistUiViewModelAsync();

            return View(model);
        }

        public async Task<IActionResult> Add(int productId)
        {
            var itemsCount = await _wishlistUiService.AddWishlistItem(productId);

            return Json(new { count = itemsCount });
        }

        public async Task<IActionResult> Remove(int id)
        {
            var itemsCount = await _wishlistUiService.RemoveFromWishlist(id);

            return Json(new { count = itemsCount });
        }
    }
}
