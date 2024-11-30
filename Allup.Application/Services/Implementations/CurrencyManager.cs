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

public class CurrencyManager : CrudManager<CurrencyViewModel, Currency, CurrencyCreateViewModel>,  ICurrencyService
{
    private readonly EfRepositoryBase<Currency, AppDbContext> _currencyRepository;

    public CurrencyManager(EfRepositoryBase<Currency, AppDbContext> currencyRepository, IMapper mapper) : base(currencyRepository, mapper)
    {
        _currencyRepository = currencyRepository;
    }

    //public async Task<List<CurrencyViewModel>> GetAllAsync(Expression<Func<Currency, bool>>? predicate = null,
    //Func<IQueryable<Currency>, IOrderedQueryable<Currency>>? orderBy = null,
    //                                Func<IQueryable<Currency>, IIncludableQueryable<Currency, object>>? include = null)
    //{
    //    var currencies = await _currencyRepository.GetAllAsync();
    //    var currencyViewModels = _mapper.Map<List<CurrencyViewModel>>(currencies);

    //    return currencyViewModels;
    //}

    //public async Task<CurrencyViewModel> GetAsync(Expression<Func<Currency, bool>> predicate, Func<IQueryable<Currency>, IIncludableQueryable<Currency, object>>? include = null)
    //{
    //    var currency = await _currencyRepository.GetAsync(predicate, include);

    //    var currencyViewModel = _mapper.Map<CurrencyViewModel>(currency);

    //    return currencyViewModel;
    //}

    //public async Task<CurrencyViewModel> GetAsync(int id)
    //{
    //    var currency = await _currencyRepository.GetAsync(id);

    //    var currencyViewModel = _mapper.Map<CurrencyViewModel>(currency);

    //    return currencyViewModel;
    //}
}
