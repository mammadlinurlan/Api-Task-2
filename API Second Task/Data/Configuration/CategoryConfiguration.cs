using API_Second_Task.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Second_Task.Data.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Image).HasMaxLength(120).IsRequired();
            builder.Property(c => c.ModifiedTime).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(c => c.CreatedTime).HasDefaultValueSql("GETUTCDATE()");

        }
    }
}
