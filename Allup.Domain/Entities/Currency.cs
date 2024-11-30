using Core.Persistence.Repositories;

namespace Allup.Domain.Entities;

public class Currency : Entity
{
    public required string Name { get; set; }
    public required string IsoCode { get; set; }
    public required string CurrencyCode { get; set; }
}