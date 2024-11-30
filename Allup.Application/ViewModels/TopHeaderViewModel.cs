namespace Allup.Application.ViewModels;

public class TopHeaderViewModel
{
    public List<LanguageViewModel>? Languages { get; set; }
    public LanguageViewModel? SelectedLanguage { get; set; }
    public List<CurrencyViewModel>? Currencies { get; set; }
    public CurrencyViewModel? SelectedCurrency { get; set; }
    public int CompareItemCount {  get; set; }
    public int WishlistItemCount {  get; set; }
    public int BasketItemCount { get; set; }
}
