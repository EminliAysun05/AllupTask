using Allup.Application.Services.Abstracts;
using Allup.Application.ViewModels;
using Allup.Domain.Entities;
using Allup.Persistence.Repositories.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Allup.Application.Services.Implementations
{
    public class CompareManager : ICompareService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IProductService _productService;
        private const string COMPARE_COOKIE_KEY = "CompareList";

        public CompareManager(IHttpContextAccessor contextAccessor, IProductService productService)
        {
            _contextAccessor = contextAccessor;
            _productService = productService;
        }

        public async Task<int> AddToCompareListAsync(int productId)
        {
            var compareListAsJson = _contextAccessor.HttpContext.Request.Cookies[COMPARE_COOKIE_KEY];
            var compareItems = new List<int>();
            var existProduct = await _productService.GetAsync(productId);

            if (compareListAsJson == null)
            {
                if (existProduct == null) return 0;

                compareItems.Add(existProduct.Id);
            }
            else
            {
                compareItems = JsonConvert.DeserializeObject<List<int>>(compareListAsJson) ?? [];

                if (compareItems.Contains(productId))
                    return compareItems.Count;

                if (existProduct == null)
                    return compareItems.Count;

                compareItems.Add(existProduct.Id);
            }

            _contextAccessor.HttpContext.Response.Cookies.Append(COMPARE_COOKIE_KEY, JsonConvert.SerializeObject(compareItems));

            return compareItems.Count;
        }

        public async Task<List<ProductViewModel>> RemoveFromCompareListAsync(int productId, int languageId)
        {
            var compareListAsJson = _contextAccessor.HttpContext.Request.Cookies[COMPARE_COOKIE_KEY];

            if (compareListAsJson == null) return [];

            var compareItems = JsonConvert.DeserializeObject<List<int>>(compareListAsJson) ?? [];

            var existProductIndex = compareItems.FindIndex(x => x == productId);

            var products = await _productService.GetAllAsync(x => compareItems.Contains(x.Id),
                           include: x => x.Include(y => y.ProductTranslations!.Where(pt => pt.LanguageId == languageId)));

            if (existProductIndex < 0) return products;

            compareItems.RemoveAt(existProductIndex);

            _contextAccessor.HttpContext.Response.Cookies.Append(COMPARE_COOKIE_KEY, JsonConvert.SerializeObject(compareItems));

            products = await _productService.GetAllAsync(x => compareItems.Contains(x.Id),
                           include: x => x.Include(y => y.ProductTranslations!.Where(pt => pt.LanguageId == languageId)));


            return products;
        }

        public async Task<List<ProductViewModel>> GetCompareItemsAsync(int languageId)
        {
            var compareListAsJson = _contextAccessor.HttpContext.Request.Cookies[COMPARE_COOKIE_KEY];

            if (compareListAsJson == null) return [];

            var compareItems = JsonConvert.DeserializeObject<List<int>>(compareListAsJson) ?? [];

            var products = await _productService.GetAllAsync(x => compareItems.Contains(x.Id),
                include: x => x.Include(y => y.ProductTranslations!.Where(pt => pt.LanguageId == languageId)));

            return products;
        }

        public int GetCount()
        {
            var compareListAsJson = _contextAccessor.HttpContext.Request.Cookies[COMPARE_COOKIE_KEY];

            if(string.IsNullOrEmpty(compareListAsJson)) return 0;

            var compareItems = JsonConvert.DeserializeObject<List<int>>(compareListAsJson) ?? [];

            return compareItems.Count;
        }
    }
}
