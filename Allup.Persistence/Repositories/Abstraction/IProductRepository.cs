using Allup.Domain.Entities;
using Core.Persistence.Repositories;

namespace Allup.Persistence.Repositories.Abstraction;

public interface IProductRepository : IRepositoryAsync<Product>
{
}