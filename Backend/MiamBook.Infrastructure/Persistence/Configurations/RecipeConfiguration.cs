using MiamBook.Business.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MiamBook.Infrastructure.Persistence.Configurations;

public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.ToTable("recipe");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
               .HasColumnName("id")
               .IsRequired();

        builder.Property(r => r.Title)
               .HasColumnName("title")
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(r => r.Description)
               .HasColumnName("description")
               .IsRequired();

        builder.Property(r => r.PreparationTime)
               .HasColumnName("preparation_time")
               .IsRequired();

        builder.Property(r => r.CookingTime)
               .HasColumnName("cooking_time")
               .IsRequired();

        builder.Property(r => r.RestTime)
               .HasColumnName("rest_time")
               .IsRequired();

        builder.Property(r => r.Servings)
               .HasColumnName("servings")
               .IsRequired();

        builder.Property(r => r.CreatedAt)
               .HasColumnName("created_at")
               .IsRequired();

        builder.Property(r => r.TypeRecipeId)
               .HasColumnName("type_recipe_id")
               .IsRequired();

        builder.Property(r => r.PhotoRecipeId)
               .HasColumnName("photo_recipe_id");

        builder.HasOne(r => r.TypeRecipe)
               .WithMany()
               .HasForeignKey(r => r.TypeRecipeId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.Photo)
               .WithOne(p => p.Recipe)
               .HasForeignKey<PhotoRecipe>(p => p.RecipeId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(r => r.Steps)
               .WithOne(s => s.Recipe)
               .HasForeignKey(s => s.RecipeId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(r => r.RecipeIngredients)
               .WithOne(ri => ri.Recipe)
               .HasForeignKey(ri => ri.RecipeId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
