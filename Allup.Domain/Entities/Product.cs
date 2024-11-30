using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allup.Domain.Entities
{
    public class Product : Entity
    {
        public required string CoverImageUrl {  get; set; }
        public required string HoverImageUrl {  get; set; }
        public decimal Price {  get; set; }
        public double Discount {  get; set; }
        public double Rate {  get; set; }
        public int Count {  get; set; }
        public string? Code {  get; set; }
        public int SellCount {  get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; } 
        public List<ProductTranslation>? ProductTranslations { get; set; }
        public List<ProductImage>? ProductImages{ get; set; }
    }

    public class ProductTranslation : Entity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int ProductId {  get; set; }
        public Product? Product { get; set; }
        public int LanguageId {  get; set; }
        public Language? Language { get; set; }
    }

    public class ProductImage : Entity
    {
        public required string ImageUrl { get; set; }
        public int ProductId {  get; set; }
        public Product? Product { get; set; }
    }
}
