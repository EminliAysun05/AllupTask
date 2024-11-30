using Allup.Application.UI.ViewModels;

namespace Allup.Application.UI.Services.Abstracts;

public interface IWishlistUiService
{
    Task<WishlistUiViewModel> GetWishlistUiViewModelAsync();
    Task<int> AddWishlistItem(int productId);
    Task<int> RemoveFromWishlist(int id);
}
