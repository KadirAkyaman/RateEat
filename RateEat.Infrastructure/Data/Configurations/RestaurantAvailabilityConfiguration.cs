using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RateEat.Core.Entities;

namespace RateEat.Infrastructure.Data.Configurations
{
    public class RestaurantAvailabilityConfiguration : IEntityTypeConfiguration<RestaurantAvailability>
    {
        public void Configure(EntityTypeBuilder<RestaurantAvailability> builder)
        {
            builder.ToTable("RestaurantAvailabilities");

            builder.HasKey(ra => ra.Id);

            builder.ToTable(tb => tb.HasCheckConstraint("CK_Availability_Seats_Not_Negative", "\"AvailableSeats\" >= 0 AND \"TotalSeats\" >= 0"));

            builder.ToTable(tb => tb.HasCheckConstraint("CK_Availability_Available_Less_Than_Total", "\"AvailableSeats\" <= \"TotalSeats\""));

            builder.HasOne(ra => ra.Restaurant).WithMany(r => r.Availabilities).HasForeignKey(ra => ra.RestaurantId).OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(ra => new { ra.RestaurantId, ra.Date, ra.TimeSlot }).IsUnique();
        }
    }
}