using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RateEat.Core.Entities;

namespace RateEat.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.PasswordHash).IsRequired();
            builder.Property(u => u.PasswordSalt).IsRequired();

            builder.Property(u => u.TrustScore).HasDefaultValue(0);
            builder.Property(u => u.IsActive).HasDefaultValue(true);

            builder.HasIndex(u => u.Email).IsUnique();

            builder.HasMany(u => u.Reviews)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);
                
            builder.HasMany(u => u.Reservations)
                .WithOne(res => res.User)
                .HasForeignKey(res => res.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}