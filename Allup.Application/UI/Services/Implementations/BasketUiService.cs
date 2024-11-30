using Allup.Application.Services.Abstracts;
using Allup.Application.UI.Services.Abstracts;
using Allup.Application.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allup.Application.UI.Services.Implementations
{
    public class BasketUiService : IBasketUiService
    {
        private readonly IBasketService _basketService;
        private readonly ICookieService _cookieService;

        public BasketUiService(IBasketService basketService, ICookieService cookieService)
        {
            _basketService = basketService;
            _cookieService = cookieService;
        }

        public async Task AddBasketItemAsync(string clientId, int productId)
        {
            await _basketService.AddBasketItemAsync(clientId, productId);
        }

        public async Task<int> GetBasketItemCount()
        {
            var clientId = _cookieService.GetBrowserId();
            var items = await _basketService.GetBasketItemsAsync(clientId);
            return items.Sum(x => x.Count);
        }

        public async Task<BasketViewModel> GetBasketUiViewModelAsync()
        {
            var clientId = _cookieService?.GetBrowserId();
            var items = await _basketService.GetBasketItemsAsync(clientId);

            return new BasketViewModel
            {
                Items = items
            };
        }

        public async Task<int> RemoveBasketItem(int productId)
        {
            var clientId = _cookieService?.GetBrowserId();
            return await _basketService.RemoveBasketItemASYNC(clientId, productId);

        }

        
    }
}
