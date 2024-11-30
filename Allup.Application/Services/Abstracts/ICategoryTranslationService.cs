using Allup.Application.ViewModels;

namespace Allup.Application.Services.Abstracts;

public interface ICategoryTranslationService
{
    Task<List<CategoryTranslationViewModel>> GetCategoryTranslationsAsync();
    Task<CategoryTranslationViewModel> GetCategoryTranslationAsync(int id);
}