namespace Allup.Application.ViewModels;

public class CategoryViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? ImageUrl { get; set; }
    public int? ParentId { get; set; }
}

public class CategoryCreateViewModel
{

}