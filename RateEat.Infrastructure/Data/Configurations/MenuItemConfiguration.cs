using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RateEat.Core.Entities;

namespace RateEat.Infrastructure.Data.Configurations
{
    public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.ToTable("MenuItems");

            builder.HasKey(mi => mi.Id);

            builder.Property(mi => mi.Name).IsRequired().HasMaxLength(20);

            builder.Property(mi => mi.Description).IsRequired().HasMaxLength(250);

            builder.Property(mi => mi.Price).HasPrecision(8, 2);

            builder.ToTable(tb => tb.HasCheckConstraint("CK_MenuItem_Price_Not_Negative", "\"Price\" >= 0"));

            builder.HasOne(mi => mi.Menu).WithMany(m => m.MenuItems).HasForeignKey(mi => mi.MenuId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}