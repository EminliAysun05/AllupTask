using Allup.Application.ViewModels;

namespace Allup.Application.UI.Services.Abstracts;

public interface ICookieService
{
    Task<LanguageViewModel> GetLanguageAsync();
    Task<CurrencyViewModel> GetCurrencyAsync();
    void AddBrowserId();
    string GetBrowserId();
}
