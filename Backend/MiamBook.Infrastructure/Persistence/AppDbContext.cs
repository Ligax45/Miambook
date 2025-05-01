using MiamBook.Business.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MiamBook.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Comment> Comment { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<PhotoRecipe> PhotoRecipe { get; set; }
    public DbSet<Recipe> Recipe { get; set; }
    public DbSet<RecipeIngredient> RecipeIngredient { get; set; }
    public DbSet<Step> Step { get; set; }
    public DbSet<TypeRecipe> TypeRecipe { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserProfile> UserProfile { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("YourConnectionString",
                x => x.MigrationsAssembly("MiamBook.Infrastructure"));
        }
    }
}
