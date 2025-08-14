using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RateEat.Core.Entities;

namespace RateEat.Infrastructure.Data.Configurations
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menus");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name).IsRequired().HasMaxLength(60);

            builder.HasOne(m => m.Restaurant).WithMany(r => r.Menus).HasForeignKey(m => m.RestaurantId).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(m => m.MenuItems).WithOne(mi => mi.Menu).HasForeignKey(mi => mi.MenuId).OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(m => new { m.RestaurantId, m.Name }).IsUnique();
        }
    }
}