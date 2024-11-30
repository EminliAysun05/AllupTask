using Allup.Application.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allup.Application.Services.Abstracts
{
    public interface IBasketService
    {
        Task<int> AddBasketItemAsync(string clientId, int productId);
        Task<int> RemoveBasketItemASYNC(string clientId, int productId);
        Task<List<BasketItemViewModel>> GetBasketItemsAsync(string clientId);
    }
}
