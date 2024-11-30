using Core.Persistence.Repositories;

namespace Allup.Domain.Entities
{
    public class Wishlist : Entity
    {
        public required string ClientId {  get; set; }
        public required int ProductId {  get; set; }
        public Product? Product { get; set; }
        public DateTime? AddedTime { get; set; }
    }
}
