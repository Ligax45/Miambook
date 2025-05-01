using MiamBook.Business.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MiamBook.Infrastructure.Persistence.Configurations;

public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
{
    public void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder.ToTable("ingredient");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id)
               .HasColumnName("id")
               .IsRequired();

        builder.Property(i => i.Name)
               .HasColumnName("name")
               .IsRequired()
               .HasMaxLength(100);

        builder.HasMany(i => i.RecipeIngredients)
               .WithOne(ri => ri.Ingredient)
               .HasForeignKey(ri => ri.IngredientId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
