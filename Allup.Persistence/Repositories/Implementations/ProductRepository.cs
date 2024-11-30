using Allup.Domain.Entities;
using Allup.Persistence.Context;
using Allup.Persistence.Repositories.Abstraction;
using Core.Persistence.Repositories;

namespace Allup.Persistence.Repositories.Implementations;

public class ProductRepository : EfRepositoryBase<Product, AppDbContext>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }
}