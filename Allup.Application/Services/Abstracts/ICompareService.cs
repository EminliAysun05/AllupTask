using Allup.Application.ViewModels;

namespace Allup.Application.Services.Abstracts;

public interface ICompareService
{
    int GetCount();
    Task<List<ProductViewModel>> GetCompareItemsAsync(int languageId);
    Task<int> AddToCompareListAsync(int productId);
    Task<List<ProductViewModel>> RemoveFromCompareListAsync(int productId, int languageId);
}
