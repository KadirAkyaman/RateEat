using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using RateEat.Core.Entities;

namespace RateEat.Infrastructure.Data.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Reviews");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Comment)
                .IsRequired()
                .HasMaxLength(1000);

            builder.ToTable(tb => tb.HasCheckConstraint("CK_Review_ServiceScore_Range", "\"ServiceScore\" >= 1 AND \"ServiceScore\" <= 5"));
            builder.ToTable(tb => tb.HasCheckConstraint("CK_Review_FlavorScore_Range", "\"FlavorScore\" >= 1 AND \"FlavorScore\" <= 5"));
            builder.ToTable(tb => tb.HasCheckConstraint("CK_Review_AmbianceScore_Range", "\"AmbianceScore\" >= 1 AND \"AmbianceScore\" <= 5"));

            builder.HasOne(r => r.User).WithMany(u => u.Reviews).HasForeignKey(r => r.UserId).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.Restaurant).WithMany(res => res.Reviews).HasForeignKey(r => r.RestaurantId).OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(r => new { r.UserId, r.RestaurantId }).IsUnique();
        }
    }
}