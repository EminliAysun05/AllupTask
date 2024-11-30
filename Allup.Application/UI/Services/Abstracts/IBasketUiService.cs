using Allup.Application.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allup.Application.UI.Services.Abstracts
{
    public interface IBasketUiService
    {
        Task<int> GetBasketItemCount();
        Task AddBasketItemAsync(string clientId, int productId);
        Task <int> RemoveBasketItem(int productId);
        Task<BasketViewModel> GetBasketUiViewModelAsync();
    }
}
