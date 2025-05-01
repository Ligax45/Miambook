using MiamBook.Business.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MiamBook.Infrastructure.Persistence.Configurations;

public class RecipeIngredientConfiguration : IEntityTypeConfiguration<RecipeIngredient>
{
    public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
    {
        builder.ToTable("recipe_ingredient");

        builder.HasKey(ri => ri.Id);

        builder.Property(ri => ri.Id)
               .HasColumnName("id")
               .IsRequired();

        builder.Property(ri => ri.RecipeId)
               .HasColumnName("recipe_id")
               .IsRequired();

        builder.Property(ri => ri.IngredientId)
               .HasColumnName("ingredient_id")
               .IsRequired();

        builder.Property(ri => ri.Quantity)
               .HasColumnName("quantity")
               .IsRequired();

        builder.Property(ri => ri.Unit)
               .HasColumnName("unit")
               .IsRequired()
               .HasMaxLength(50);

        builder.HasOne(ri => ri.Recipe)
               .WithMany(r => r.RecipeIngredients)
               .HasForeignKey(ri => ri.RecipeId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ri => ri.Ingredient)
               .WithMany(i => i.RecipeIngredients)
               .HasForeignKey(ri => ri.IngredientId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
