namespace Allup.Application.ViewModels;

public class ProductViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? CoverImageUrl { get; set; }
    public string? HoverImageUrl { get; set; }
    public decimal Price { get; set; }
    public string? FormattedPrice { get; set; }
    public double Discount { get; set; }
    public double Rate { get; set; }
    public int Count { get; set; }
    public string? Code { get; set; }
    public int SellCount { get; set; }
    public List<string>? Images { get; set; }
}

public class ProductCreateViewModel { }
