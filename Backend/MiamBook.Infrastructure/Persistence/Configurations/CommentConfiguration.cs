using MiamBook.Business.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MiamBook.Infrastructure.Persistence.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("comment");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
               .HasColumnName("id")
               .IsRequired();

        builder.Property(c => c.Content)
               .HasColumnName("content")
               .IsRequired()
               .HasMaxLength(1000);

        builder.Property(c => c.CreatedAt)
               .HasColumnName("created_at")
               .IsRequired();

        builder.Property(c => c.RecipeId)
               .HasColumnName("recipe_id")
               .IsRequired();

        builder.Property(c => c.UserProfileId)
               .HasColumnName("user_profile_id")
               .IsRequired();

        builder.HasOne(c => c.Recipe)
               .WithMany(r => r.Comments)
               .HasForeignKey(c => c.RecipeId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(c => c.UserProfile)
               .WithMany(up => up.Comments)
               .HasForeignKey(c => c.UserProfileId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
