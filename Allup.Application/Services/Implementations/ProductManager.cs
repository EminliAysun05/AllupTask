using Allup.Application.Services.Abstracts;
using Allup.Application.UI.Services.Abstracts;
using Allup.Application.UI.Services.Implementations;
using Allup.Application.ViewModels;
using Allup.Domain.Entities;
using Allup.Persistence.Context;
using Allup.Persistence.Repositories.Abstraction;
using AutoMapper;
using Core.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Globalization;
using System.Linq.Expressions;

namespace Allup.Application.Services.Implementations;

public class ProductManager :  CrudManager<ProductViewModel, Product, ProductCreateViewModel>, IProductService
{
    private readonly EfRepositoryBase<Product, AppDbContext> _repository;
    private readonly ExternalApiService _externalApiService;
    private readonly ICurrencyService _currencyService;
    private readonly ICookieService _cookieService;

    public ProductManager(EfRepositoryBase<Product, AppDbContext> repository, IMapper mapper, ExternalApiService externalApiService, ICurrencyService currencyService, ICookieService cookieService) : base(repository, mapper)
    {
        _repository = repository;
        _externalApiService = externalApiService;
        _currencyService = currencyService;
        _cookieService = cookieService;
    }

    public override async Task<List<ProductViewModel>> GetAllAsync(Expression<Func<Product, bool>>? predicate = null,
                                    Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null,
                                    Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null)
    {
        var products = await _repository.GetAllAsync(predicate, orderBy, include);

        var productViewModels = Mapper.Map<List<ProductViewModel>>(products);

        var currency = await _cookieService.GetCurrencyAsync();

        var coefficient = await _externalApiService.GetCurrencyCoefficient(currency.CurrencyCode ?? "azn");
        var culture = new CultureInfo(currency.IsoCode?? "az-az");

        foreach (var item in productViewModels)
        {
            item.FormattedPrice = (item.Price / coefficient).ToString("C", culture);
        }

        return productViewModels;
    }

    public override async Task<ProductViewModel> GetAsync(Expression<Func<Product, bool>> predicate, Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null)
    {
        var product = await _repository.GetAsync(predicate, include);
        
        var productViewModel = Mapper.Map<ProductViewModel>(product);

        var currency = await _cookieService.GetCurrencyAsync();

        var coefficient = await _externalApiService.GetCurrencyCoefficient(currency.CurrencyCode ?? "azn");
        var culture = new CultureInfo(currency.IsoCode?? "az-az");

        productViewModel.FormattedPrice = (productViewModel.Price / coefficient).ToString("C", culture);

        return productViewModel;
    }

    //public async Task<ProductViewModel> GetAsync(int id)
    //{
    //    var product = await _repository.GetAsync(id);
    //    var productViewModel = _mapper.Map<ProductViewModel>(product);

    //    return productViewModel;
    //}
}
