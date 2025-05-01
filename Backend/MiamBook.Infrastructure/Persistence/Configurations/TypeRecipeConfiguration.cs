using MiamBook.Business.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MiamBook.Infrastructure.Persistence.Configurations;

public class TypeRecipeConfiguration : IEntityTypeConfiguration<TypeRecipe>
{
    public void Configure(EntityTypeBuilder<TypeRecipe> builder)
    {
        builder.ToTable("type_recipe");

        builder.HasKey(tr => tr.Id);

        builder.Property(tr => tr.Id)
               .HasColumnName("id")
               .IsRequired();

        builder.Property(tr => tr.Name)
               .HasColumnName("name")
               .IsRequired()
               .HasMaxLength(100);

        builder.HasMany(tr => tr.Recipes)
               .WithOne(r => r.TypeRecipe)
               .HasForeignKey(r => r.TypeRecipeId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
