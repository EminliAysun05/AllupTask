using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Allup.Application.Services.Abstracts
{
    public interface ICrudService<TViewModel, TEntity, TCreateViewModel> 
    {
        Task<TViewModel> GetAsync(int id);
        Task<TViewModel> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);
        Task<List<TViewModel>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null,
                                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);
        Task<TViewModel> CreateAsync(TCreateViewModel createViewModel);
        Task Remove(int id);
    }
}
