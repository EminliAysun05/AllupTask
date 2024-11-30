using Allup.Application.Services.Abstracts;
using Allup.Application.UI.ViewModels;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Allup.MVC.ViewComponenets
{
    public class BasketViewComponent :  ViewComponent
    {
        private readonly IProductService _productService;
        private readonly ILanguageService _languageService;

        public BasketViewComponent(IProductService productService, ILanguageService languageService)
        {
            _productService = productService;
            _languageService = languageService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var basket = Request.Cookies["basket"];
            var basketViewModel = new BasketViewModel();
            var basketItemViewModels = new List<BasketItemViewModel>();

            if (string.IsNullOrEmpty(basket))
            {
                return View(basketViewModel);
            }

            var basketCookieViewModels = JsonConvert.DeserializeObject<List<BasketCookieViewModel>>(basket);


            var culture = Request.Cookies[CookieRequestCultureProvider.DefaultCookieName];
            var isoCode = culture?.Substring(culture.LastIndexOf("=") + 1) ?? "en-Us";
            var selectedLanguage = await _languageService.GetAsync(x => x.IsoCode == isoCode);

            foreach (var item in basketCookieViewModels ?? [])
            {
                var existBasketItem = await _productService.GetAsync(x => x.Id == item.ProductId, 
                    x => x.Include(y => y.ProductTranslations!.Where(z => z.LanguageId == selectedLanguage.Id)));

                if (existBasketItem == null) continue;

                basketItemViewModels.Add(new BasketItemViewModel
                {
                    ProductId = existBasketItem.Id,
                    Name = existBasketItem.Name,
                    Price = existBasketItem.Price,
                    CoverImageUrl = existBasketItem?.CoverImageUrl,
                    FormattedPrice = existBasketItem?.FormattedPrice,
                    Count = item.Count
                });
            }

            //var totalAmount = basketItemViewModels.Sum(x => x.Price * x.Count);

            basketViewModel.Items = basketItemViewModels;
            //basketViewModel.TotalAmount = totalAmount;
            TempData["Count"] = basketViewModel.Count;
            return View(basketViewModel);
        }
    }
}
