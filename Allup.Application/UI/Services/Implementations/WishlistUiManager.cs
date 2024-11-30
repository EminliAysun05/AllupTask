using Allup.Application.Services.Abstracts;
using Allup.Application.UI.Services.Abstracts;
using Allup.Application.UI.ViewModels;
using Allup.Application.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allup.Application.UI.Services.Implementations
{
    public class WishlistUiManager : IWishlistUiService
    {
        private readonly IWishlistService _wishlistService;
        private readonly ICookieService _cookieService;

        public WishlistUiManager(IWishlistService wishlistService, ICookieService cookieService)
        {
            _wishlistService = wishlistService;
            _cookieService = cookieService;
        }

        public async Task<int> AddWishlistItem(int productId)
        {
            var clientId = _cookieService.GetBrowserId();

            var wishListCreateViewModel = new WishlistCreateViewModel { ClientId = clientId, ProductId = productId};

            await _wishlistService.CreateAsync(wishListCreateViewModel);

            var itemsCount = (await _wishlistService.GetAllAsync(x => x.ClientId == clientId)).Count;

            return itemsCount;
        }

        public async Task<WishlistUiViewModel> GetWishlistUiViewModelAsync()
        {
            var clientId = _cookieService.GetBrowserId();
            var language = await _cookieService.GetLanguageAsync();

            var wishlistItems = await _wishlistService.GetAllAsync(x => x.ClientId == clientId,
                include: x => x.Include(y => y.Product)
                .ThenInclude(p => p!.ProductTranslations!
                .Where(pt => pt.LanguageId == language.Id)));

            return new WishlistUiViewModel
            {
                WishlistItems = wishlistItems,
            };
        }

        public async Task<int> RemoveFromWishlist(int id)
        {
            var clientId = _cookieService.GetBrowserId();

            await _wishlistService.Remove(id);

            var itemsCount = (await _wishlistService.GetAllAsync(x => x.ClientId == clientId)).Count;

            return itemsCount;
        }
    }
}
