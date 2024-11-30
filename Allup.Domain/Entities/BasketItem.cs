using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allup.Domain.Entities
{
    public class BasketItem : Entity
    {
        public int Id { get; set; }
        public string ClientId { get; set; } = null!;
        public int ProductId { get; set; }
        public int Count { get; set; } = 1;

        public Product Product { get; set; } = null!;
    }
}
