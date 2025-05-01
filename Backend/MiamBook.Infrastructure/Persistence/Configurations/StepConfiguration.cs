using MiamBook.Business.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MiamBook.Infrastructure.Persistence.Configurations;

public class StepConfiguration : IEntityTypeConfiguration<Step>
{
    public void Configure(EntityTypeBuilder<Step> builder)
    {
        builder.ToTable("step");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
               .HasColumnName("id")
               .IsRequired();

        builder.Property(s => s.Description)
               .HasColumnName("description")
               .IsRequired()
               .HasMaxLength(1000);

        builder.Property(s => s.RecipeId)
               .HasColumnName("recipe_id")
               .IsRequired();

        builder.HasOne(s => s.Recipe)
               .WithMany(r => r.Steps)
               .HasForeignKey(s => s.RecipeId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
