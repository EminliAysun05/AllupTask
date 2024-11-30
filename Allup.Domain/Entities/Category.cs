using Core.Persistence.Repositories;

namespace Allup.Domain.Entities
{
    public class Category : Entity
    {
        public string? ImageUrl {  get; set; }
        public int? ParentId { get; set; }
        public Category? Parent { get; set; }
        public List<Category>? SubCategories { get; set; }
        public List<CategoryTranslation>? CategoryTranslations { get; set; }
        public List<Product>? Products { get; set; }
    }

    public class CategoryTranslation : Entity
    {
        public required string Name {  get; set; }
        public int CategoryId {  get; set; }
        public Category? Category { get; set; }
        public int LanguageId {  get; set; }
        public Language? Language { get; set; }
    }
}
