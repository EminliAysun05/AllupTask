using Allup.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Allup.Persistence.Context;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions options) : base(options)
    {

    }

    public required DbSet<Language> Languages { get; set; }
    public required DbSet<Currency> Currencies { get; set; }
    public required DbSet<Category> Categories { get; set; }
    public required DbSet<CategoryTranslation> CategoriesTranslations { get; set; }
    public required DbSet<Product> Products { get; set; }
    public required DbSet<ProductTranslation> ProductTranslations { get; set; }
    public required DbSet<ProductImage> ProductImages { get; set; }

    public DbSet<BasketItem> BasketItems { get; set; }
    public required DbSet<Wishlist> WishlistItems { get; set; }
}
