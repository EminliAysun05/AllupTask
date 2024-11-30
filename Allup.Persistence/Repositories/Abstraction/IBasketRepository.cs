using Allup.Domain.Entities;
using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allup.Persistence.Repositories.Abstraction
{
    public interface IBasketRepository : IRepositoryAsync<BasketItem>
    {
    }
}
