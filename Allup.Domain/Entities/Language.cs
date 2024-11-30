using Core.Persistence.Repositories;

namespace Allup.Domain.Entities;

public class Language : Entity
{
    public required string Name {  get; set; }
    public required string IsoCode {  get; set; }
    public required string ImageUrl { get; set; }
}