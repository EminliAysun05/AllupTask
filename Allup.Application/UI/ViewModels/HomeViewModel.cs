using Allup.Application.ViewModels;

namespace Allup.Application.UI.ViewModels;

public class HomeViewModel
{
    public List<CategoryViewModel>? Categories { get; set; }
    public List<ProductViewModel>? Products { get; set; }
}
