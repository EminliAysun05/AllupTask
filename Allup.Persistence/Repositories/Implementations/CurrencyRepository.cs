using Allup.Domain.Entities;
using Allup.Persistence.Context;
using Allup.Persistence.Repositories.Abstraction;
using Core.Persistence.Repositories;

namespace Allup.Persistence.Repositories.Implementations;

public class CurrencyRepository : EfRepositoryBase<Currency, AppDbContext>, ICurrencyRepository
{
    public CurrencyRepository(AppDbContext context) : base(context)
    {
    }
}