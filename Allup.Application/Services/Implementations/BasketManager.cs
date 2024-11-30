using Allup.Application.Services.Abstracts;
using Allup.Application.UI.Services.Abstracts;
using Allup.Application.UI.Services.Implementations;
using Allup.Application.UI.ViewModels;
using Allup.Application.ViewModels;
using Allup.Domain.Entities;
using Allup.Persistence.Context;
using Allup.Persistence.Repositories.Implementations;
using AutoMapper;
using Core.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Allup.Application.Services.Implementations;

public class BasketManager : CrudManager<BasketViewModel, BasketItem, BasketCreateViewModel>, IBasketService
{
    private readonly EfRepositoryBase<BasketItem, AppDbContext> _repository;
    private readonly IProductService _productService;
    private readonly IRepositoryAsync<BasketItem> _basketRepository;
    private readonly ICookieService _cookieService;
    private readonly ExternalApiService _externalApiService;


    public BasketManager(IProductService productService,EfRepositoryBase<BasketItem, AppDbContext> repository, IMapper mapper, ICookieService cookieService, ExternalApiService externalApiService) : base(repository ,mapper)
    {
        _basketRepository = repository;
        _repository = repository;
        _cookieService = cookieService;
        _externalApiService = externalApiService;
        _productService = productService;
    }
    //public BasketManager(IProductService productService, IRepositoryAsync<BasketItem> basketRepository)
    //{
    //    _productService = productService;
    //    _basketRepository = basketRepository;
    //}

    public async Task<int> AddBasketItemAsync(string clientId, int productId)
    {
        var existingItem = await _basketRepository.GetAsync(x => x.ClientId == clientId && x.ProductId == productId);

        if(existingItem != null)
        {
            existingItem.Count++;   
            await _basketRepository.UpdateAsync(existingItem);
        }
        else
        {
            var newItem = new BasketItem
            {
                ClientId = clientId,
                ProductId = productId,
                Count = 1
            };
            await _basketRepository.AddAsync(newItem);
        }

        return (await _basketRepository.GetAllAsync(x => x.ClientId == clientId)).Count();        }

    public async Task<List<BasketItemViewModel>> GetBasketItemsAsync(string clientId)
    {
        var items = await _basketRepository.GetAllAsync(x => x.ClientId == clientId,
           include: x => x.Include(y => y.Product));


        return items.Select(x => new BasketItemViewModel
        {
            ProductId = x.ProductId,
            Name = x.Product.ProductTranslations!.FirstOrDefault()?.Name ?? "N/A", // Tərcümə edilmiş adı alın
            Price = x.Product.Price,
            CoverImageUrl = x.Product.CoverImageUrl,
            Count = x.Count
        }).ToList();

    }

    public async Task<int> RemoveBasketItemASYNC(string clientId, int productId)
    {
       var existingItem = await _basketRepository.GetAsync(x=>x.ClientId == clientId &&  x.ProductId == productId);

        if (existingItem != null)
        {
            await _basketRepository.DeleteAsync(existingItem);
        }

        return (await _basketRepository.GetAllAsync(x=>x.ClientId == clientId && x.ProductId == productId)).Count(); 

    }
}
