using Allup.Application.ViewModels;
using Allup.Domain.Entities;

namespace Allup.Application.Services.Abstracts;

public interface ILanguageService : ICrudService<LanguageViewModel, Language, LanguageCreateViewModel>
{
}