using Allup.Domain.Entities;
using Core.Persistence.Repositories;

namespace Allup.Persistence.Repositories.Abstraction;

public interface ICategoryRepository : IRepositoryAsync<Category>
{
}
