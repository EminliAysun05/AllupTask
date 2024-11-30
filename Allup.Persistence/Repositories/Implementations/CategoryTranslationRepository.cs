using Allup.Domain.Entities;
using Allup.Persistence.Context;
using Allup.Persistence.Repositories.Abstraction;
using Core.Persistence.Repositories;

namespace Allup.Persistence.Repositories.Implementations;

public class CategoryTranslationRepository : EfRepositoryBase<CategoryTranslation, AppDbContext>, ICategoryTranslationRepository
{
    public CategoryTranslationRepository(AppDbContext context) : base(context)
    {
    }
}
