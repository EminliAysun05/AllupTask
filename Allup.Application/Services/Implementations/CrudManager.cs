using Allup.Application.Services.Abstracts;
using Allup.Application.ViewModels;
using Allup.Persistence.Context;
using AutoMapper;
using Core.Persistence.Repositories;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Allup.Application.Services.Implementations
{
    public class CrudManager<TViewModel, TEntity, TCreateViewModel> : ICrudService<TViewModel, TEntity, TCreateViewModel> where TEntity: Entity
    {
        private readonly EfRepositoryBase<TEntity,AppDbContext> _repository;
        protected IMapper Mapper;

        public CrudManager(EfRepositoryBase<TEntity, AppDbContext> repository, IMapper mapper)
        {
            _repository = repository;
            Mapper = mapper;
        }

        public virtual async Task<TViewModel> CreateAsync(TCreateViewModel createViewModel)
        {
            var entity = Mapper.Map<TEntity>(createViewModel);

            var createdEntity = await _repository.AddAsync(entity);

            return Mapper.Map<TViewModel>(createdEntity);
        }

        public virtual async Task<List<TViewModel>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            var entities = await _repository.GetAllAsync(predicate, orderBy, include);
            var viewModels = Mapper.Map<List<TViewModel>>(entities);

            return viewModels;
        }

        public virtual async Task<TViewModel> GetAsync(int id)
        {
            var entity = await _repository.GetAsync(id);
            var viewModel = Mapper.Map<TViewModel>(entity);

            return viewModel;
        }

        public virtual async Task<TViewModel> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            var entity = await _repository.GetAsync(predicate, include);
            var viewModel = Mapper.Map<TViewModel>(entity);

            return viewModel;
        }

        public async Task Remove(int id)
        {
            var existEntity = await _repository.GetAsync(id);

            if (existEntity == null) return;

            await _repository.DeleteAsync(existEntity);
        }
    }
}
