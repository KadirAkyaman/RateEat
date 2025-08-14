using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RateEat.Core.Entities;

namespace RateEat.Infrastructure.Data.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservations");

            builder.HasKey(res => res.Id);

            builder.Property(res => res.Status)
                .IsRequired()
                .HasMaxLength(20);
            
            builder.ToTable(tb => tb.HasCheckConstraint("CK_Reservation_PartySize_Positive", "\"PartySize\" > 0"));

            builder.HasOne(res => res.User)
                .WithMany(u => u.Reservations)
                .HasForeignKey(res => res.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(res => res.Restaurant)
                .WithMany(r => r.Reservations)
                .HasForeignKey(res => res.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(res => new { res.UserId, res.ReservationDate })
                .IsUnique();
        }
    }
}