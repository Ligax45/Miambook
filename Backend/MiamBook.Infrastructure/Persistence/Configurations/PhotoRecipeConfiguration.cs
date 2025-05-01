using MiamBook.Business.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MiamBook.Infrastructure.Persistence.Configurations;

public class PhotoRecipeConfiguration : IEntityTypeConfiguration<PhotoRecipe>
{
    public void Configure(EntityTypeBuilder<PhotoRecipe> builder)
    {
        builder.ToTable("photo_recipe");

        builder.HasKey(pr => pr.Id);

        builder.Property(pr => pr.Id)
               .HasColumnName("id")
               .IsRequired();

        builder.Property(pr => pr.Name)
               .HasColumnName("name")
               .IsRequired()
               .HasMaxLength(255);

        builder.Property(pr => pr.Blob)
               .HasColumnName("blob")
               .IsRequired();

        builder.Property(pr => pr.RecipeId)
               .HasColumnName("recipe_id")
               .IsRequired();

        builder.HasOne(pr => pr.Recipe)
               .WithOne(r => r.Photo)
               .HasForeignKey<PhotoRecipe>(pr => pr.RecipeId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
