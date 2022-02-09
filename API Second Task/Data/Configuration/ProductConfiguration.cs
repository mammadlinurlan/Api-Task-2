using API_Second_Task.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Second_Task.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Cost).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(c => c.Price).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(c => c.ModifiedTime).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(c => c.CreatedTime).HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
