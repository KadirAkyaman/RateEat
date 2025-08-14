using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RateEat.Core.Entities;

namespace RateEat.Infrastructure.Data.Configurations
{
    public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.ToTable("Restaurants");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Name).IsRequired().HasMaxLength(60);

            builder.Property(r => r.Description).HasMaxLength(600);

            builder.Property(r => r.Address).IsRequired().HasMaxLength(250);

            builder.Property(r => r.PhoneNumber).IsRequired().HasMaxLength(11);

            builder.Property(r => r.CuisineType).HasMaxLength(40);

            builder.Property(r => r.IsActive).HasDefaultValue(true);

            builder.Property(r => r.OverallScore).HasDefaultValue(0);

            builder.ToTable(tb => tb.HasCheckConstraint("CK_Restaurant_OverallScore_Range", "\"OverallScore\" >= 0 AND \"OverallScore\" <= 5"));

            builder.HasMany(r => r.Reviews).WithOne(rev => rev.Restaurant).HasForeignKey(rev => rev.RestaurantId).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(r => r.Reservations).WithOne(res => res.Restaurant).HasForeignKey(res => res.RestaurantId).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(r => r.Menus).WithOne(m => m.Restaurant).HasForeignKey(m => m.RestaurantId).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(r => r.Availabilities).WithOne(a => a.Restaurant).HasForeignKey(a => a.RestaurantId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}