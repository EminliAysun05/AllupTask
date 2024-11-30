using Allup.Application.Services.Abstracts;
using Allup.Application.UI.Services.Abstracts;
using Allup.Application.UI.Services.Implementations;
using Allup.Application.ViewModels;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Allup.MVC.ViewComponenets
{
    public class TopHeaderViewComponent : ViewComponent
    {
        private readonly ILanguageService _languageService;
        private readonly ICurrencyService _currencyService;
        private readonly ICompareService _compareService;
        private readonly ICookieService _cookieService;
        private readonly IWishlistService _wishlistService;
        private readonly IBasketUiService _basketUiService;

        public TopHeaderViewComponent(IBasketUiService basketUiService, ILanguageService languageService, ICompareService compareService, ICurrencyService currencyService, ICookieService cookieService, IWishlistService wishlistService)
        {
            _languageService = languageService;
            _compareService = compareService;
            _currencyService = currencyService;
            _cookieService = cookieService;
            _wishlistService = wishlistService;
            _basketUiService = basketUiService;
        }

        public async Task<ViewViewComponentResult> InvokeAsync()
        {
            var browserId = _cookieService.GetBrowserId();
            var languages = await _languageService.GetAllAsync();
            var currencies = await _currencyService.GetAllAsync();
            var compareItemCount = _compareService.GetCount();
            var wishlistItemCount = (await _wishlistService.GetAllAsync(x => x.ClientId == browserId)).Count;
            var basketItemCount = await _basketUiService.GetBasketItemCount();

            var topHeaderViewModel = new TopHeaderViewModel
            {
                Languages = languages,
                SelectedLanguage = await _cookieService.GetLanguageAsync(),
                CompareItemCount = compareItemCount,
                Currencies = currencies,
                SelectedCurrency = await _cookieService.GetCurrencyAsync(),
                WishlistItemCount = wishlistItemCount,
                BasketItemCount = basketItemCount
            };

            return View(topHeaderViewModel);
        }
    }
}
