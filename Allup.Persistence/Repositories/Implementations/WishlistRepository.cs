using Allup.Domain.Entities;
using Allup.Persistence.Context;
using Allup.Persistence.Repositories.Abstraction;
using Core.Persistence.Repositories;

namespace Allup.Persistence.Repositories.Implementations;

public class WishlistRepository : EfRepositoryBase<Wishlist, AppDbContext>, IWishlistRepository
{
    public WishlistRepository(AppDbContext context) : base(context)
    {
    }
}