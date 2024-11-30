using Allup.Application.UI.ViewModels;

namespace Allup.Application.UI.Services.Abstracts;

public interface IHomeService
{
    Task<HomeViewModel> GetHomeViewModelAsync();
}