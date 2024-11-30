using Allup.Domain.Entities;
using Allup.Persistence.Context;
using Allup.Persistence.Repositories.Abstraction;
using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allup.Persistence.Repositories.Implementations
{
    public class BasketRepository : EfRepositoryBase<BasketItem, AppDbContext>, IBasketRepository
    {
        public BasketRepository(AppDbContext context) : base(context)
        {
        }
    }

}
