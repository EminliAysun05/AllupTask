using Allup.Application.Services.Abstracts;
using Allup.Application.ViewModels;
using Allup.Domain.Entities;
using Allup.Persistence.Context;
using Allup.Persistence.Repositories.Abstraction;
using AutoMapper;
using Core.Persistence.Repositories;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq.Expressions;

namespace Allup.Application.Services.Implementations;

public class LanguageManager : CrudManager<LanguageViewModel, Language, LanguageCreateViewModel>,  ILanguageService
{
    private readonly EfRepositoryBase<Language,  AppDbContext> _languageRepository;

    public LanguageManager(EfRepositoryBase<Language, AppDbContext> languageRepository, IMapper mapper) : base(languageRepository, mapper)
    {
        _languageRepository = languageRepository;
    }

    //public async Task<List<LanguageViewModel>> GetAllAsync(Expression<Func<Language, bool>>? predicate = null,
    //Func<IQueryable<Language>, IOrderedQueryable<Language>>? orderBy = null,
    //                                Func<IQueryable<Language>, IIncludableQueryable<Language, object>>? include = null)
    //{
    //    var languages = await _languageRepository.GetAllAsync();
    //    var languagesViewModels = _mapper.Map<List<LanguageViewModel>>(languages);

    //    return languagesViewModels;
    //}

    //public async Task<LanguageViewModel> GetAsync(Expression<Func<Language, bool>> predicate, Func<IQueryable<Language>, IIncludableQueryable<Language, object>>? include = null)
    //{
    //    var language = await _languageRepository.GetAsync(predicate, include);

    //    var languageViewModel = _mapper.Map<LanguageViewModel>(language);

    //    return languageViewModel;
    //}

    //public async Task<LanguageViewModel> GetAsync(int id)
    //{
    //    var language = await _languageRepository.GetAsync(id);

    //    var languageViewModel = _mapper.Map<LanguageViewModel>(language);

    //    return languageViewModel;
    //}
}
