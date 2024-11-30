using Azure.Core;

namespace Allup.Application.ViewModels;

public class WishlistViewModel
{
    public int Id { get; set; }
    public string? ClientId {  get; set; }
    public ProductViewModel? Product { get; set; }
}

public class WishlistCreateViewModel
{
    public required string ClientId {  get; set; }
    public required int ProductId {  get; set; }
}