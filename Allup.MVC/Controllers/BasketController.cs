using Allup.Application.Services.Abstracts;
using Allup.Application.UI.Services.Abstracts;
using Allup.Application.UI.ViewModels;
using Allup.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace Allup.MVC.Controllers
{
    public class BasketController : LocalizerController
    {
        private readonly IBasketUiService _basketUiService;
        private readonly IBasketService _basketService;
        private readonly ICookieService _cookieService;

        public BasketController(ICookieService _cookieService,IBasketService basketService,IBasketUiService basketUiService, ILanguageService languageService) : base(languageService)
        {
            _basketUiService = basketUiService;
            _basketService = basketService;

        }

        public async Task<IActionResult> Index()
        {
            var model = await _basketUiService.GetBasketUiViewModelAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(int productId)
        {
            if (productId <= 0)
            {
                return BadRequest(new { success = false, message = "Invalid product ID." });
            }

            var clientId = _cookieService.GetBrowserId();

            await _basketUiService.AddBasketItemAsync(clientId, productId);

            var basketItemCount = await _basketUiService.GetBasketItemCount();

            return Json(new { success = true, basketItemCount });
        }


        public async Task<IActionResult> Remove(int productId)
        {
            var itemCount = await _basketUiService.RemoveBasketItem(productId);
            return Json(new { count = itemCount });
        }

        public async Task<int> GetBasketItemCount(string clientId)
        {
            var items = await _basketService.GetBasketItemsAsync(clientId);
            return items.Sum(x=> x.Count);
        }

        //private readonly IProductService _productService;

        //public BasketController(IProductService productService, ILanguageService languageService) : base(languageService)
        //{
        //    _productService = productService;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public async Task<IActionResult> AddBasket(int productId)
        //{
        //    var basket = Request.Cookies["basket"];
        //    var basketViewModel = new BasketViewModel();
        //    var basketCookieViewModels = new List<BasketCookieViewModel>();
        //    var basketItemViewModels = new List<BasketItemViewModel>();

        //    var languageId = await GetLanguageAsync();

        //    if (string.IsNullOrEmpty(basket))
        //    {
        //        basketCookieViewModels.Add(new BasketCookieViewModel
        //        {
        //            Count = 1,
        //            ProductId = productId
        //        });
        //    }
        //    else
        //    {
        //        basketCookieViewModels = JsonConvert.DeserializeObject<List<BasketCookieViewModel>>(basket) ?? [];

        //        if (basketCookieViewModels.Any(x => x.ProductId == productId))
        //        {
        //            var existBasketItem = basketCookieViewModels.Find(x => x.ProductId == productId);
        //            existBasketItem!.Count++;
        //        }
        //        else
        //        {
        //            basketCookieViewModels.Add(new BasketCookieViewModel
        //            {
        //                Count = 1,
        //                ProductId = productId
        //            });
        //        }    
        //    }

        //    Response.Cookies.Append("basket", JsonConvert.SerializeObject(basketCookieViewModels));

        //    foreach (var item in basketCookieViewModels ?? [])
        //    {
        //        var existBasketItem = await _productService.GetAsync(x => x.Id == item.ProductId,
        //            x => x.Include(y => y.ProductTranslations!.Where(z => z.LanguageId == languageId)));

        //        if (existBasketItem == null) continue;

        //        basketItemViewModels.Add(new BasketItemViewModel
        //        {
        //            ProductId = existBasketItem.Id,
        //            Name = existBasketItem.Name,
        //            CoverImageUrl = existBasketItem.CoverImageUrl,
        //            Price = existBasketItem.Price,
        //            Count = item.Count
        //        });
        //    }

        //    //var totalAmount = basketItemViewModels.Sum(x => x.Price * x.Count);

        //    basketViewModel.Items = basketItemViewModels;
        //    //basketViewModel.TotalAmount = totalAmount;

        //    return Json(basketViewModel);
        //}

        //public async Task<IActionResult> Remove(int productId)
        //{
        //    var basket = Request.Cookies["basket"];
        //    var basketViewModel = new BasketViewModel();
        //    var basketItemViewModels = new List<BasketItemViewModel>();
        //    var languageId = await GetLanguageAsync();

        //    if (string.IsNullOrEmpty(basket))
        //    {
        //        return BadRequest();
        //    }

        //    var basketCookieViewModels = JsonConvert.DeserializeObject<List<BasketCookieViewModel>>(basket);

        //    var existProduct = basketCookieViewModels.Find(x => x.ProductId == productId);

        //    if (existProduct == null)
        //        return BadRequest();

        //    basketCookieViewModels.Remove(existProduct);
        //    Response.Cookies.Append("basket", JsonConvert.SerializeObject(basketCookieViewModels));

        //    foreach (var item in basketCookieViewModels ?? [])
        //    {
        //        var existBasketItem = await _productService.GetAsync(x => x.Id == item.ProductId,
        //            x => x.Include(y => y.ProductTranslations!.Where(z => z.LanguageId == languageId)));

        //        if (existBasketItem == null) continue;

        //        basketItemViewModels.Add(new BasketItemViewModel
        //        {
        //            ProductId = existBasketItem.Id,
        //            Name = existBasketItem.Name,
        //            CoverImageUrl = existBasketItem.CoverImageUrl,
        //            Price = existBasketItem.Price,
        //            Count = item.Count
        //        });
        //    }

        //    //var totalAmount = basketItemViewModels.Sum(x => x.Price * x.Count);

        //    basketViewModel.Items = basketItemViewModels;
        //    //basketViewModel.TotalAmount = totalAmount;
        //    return Json(basketViewModel);
        //}
    }
}
