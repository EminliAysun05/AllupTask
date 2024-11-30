using Allup.Domain.Entities;
using Allup.Persistence.Context;
using Allup.Persistence.Repositories.Abstraction;
using Core.Persistence.Repositories;

namespace Allup.Persistence.Repositories.Implementations;

public class LanguageRepository : EfRepositoryBase<Language, AppDbContext>, ILanguageRepository
{
    public LanguageRepository(AppDbContext context) : base(context)
    {
    }
}