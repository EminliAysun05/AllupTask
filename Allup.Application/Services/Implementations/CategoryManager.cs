using Allup.Application.Services.Abstracts;
using Allup.Application.UI.Services.Abstracts;
using Allup.Application.ViewModels;
using Allup.Domain.Entities;
using Allup.Persistence.Context;
using Allup.Persistence.Repositories.Abstraction;
using AutoMapper;
using Core.Persistence.Repositories;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Allup.Application.Services.Implementations
{
    public class CategoryManager : CrudManager<CategoryViewModel, Category, CategoryCreateViewModel>, ICategoryService
    {
        private readonly EfRepositoryBase<Category, AppDbContext> _repository;

        public CategoryManager(EfRepositoryBase<Category, AppDbContext> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }

        //public async Task<List<CategoryViewModel>> GetAllAsync(Expression<Func<Category, bool>>? predicate = null,
        //                            Func<IQueryable<Category>, IOrderedQueryable<Category>>? orderBy = null,
        //                            Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null)
        //{
        //    var categories = await _repository.GetAllAsync(predicate, orderBy, include);

        //    var categoryViewModels = _mapper.Map<List<CategoryViewModel>>(categories);

        //    return categoryViewModels;
        //}

        //public async Task<CategoryViewModel> GetAsync(Expression<Func<Category, bool>> predicate, Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null)
        //{
        //    var category = await _repository.GetAsync(predicate, include);

        //    var categoryViewModel = _mapper.Map<CategoryViewModel>(category);

        //    return categoryViewModel;
        //}

        //public async Task<CategoryViewModel> GetAsync(int id)
        //{
        //    var category = await _repository.GetAsync(id);

        //    var categoryViewModel = _mapper.Map<CategoryViewModel>(category);

        //    return categoryViewModel;
        //}
    }
}
