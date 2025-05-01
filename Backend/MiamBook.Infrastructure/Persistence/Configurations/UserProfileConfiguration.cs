using MiamBook.Business.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MiamBook.Infrastructure.Persistence.Configurations;

public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.ToTable("user_profile");

        builder.HasKey(up => up.Id);

        builder.Property(up => up.Id)
               .HasColumnName("id")
               .IsRequired();

        builder.Property(up => up.FirstName)
               .HasColumnName("first_name")
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(up => up.LastName)
               .HasColumnName("last_name")
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(up => up.UserId)
               .HasColumnName("user_id")
               .IsRequired();

        builder.HasOne(up => up.User)
               .WithOne()
               .HasForeignKey<UserProfile>(up => up.UserId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(up => up.Comments)
               .WithOne(c => c.UserProfile)
               .HasForeignKey(c => c.UserProfileId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
