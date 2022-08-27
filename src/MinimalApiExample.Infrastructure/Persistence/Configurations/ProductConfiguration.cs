using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinimalApiExample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApiExample.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.ProductId);

            builder.Property(e => e.Name)
                .IsRequired().HasMaxLength(100);

            builder.Property(e => e.Description)
                .IsRequired();

            // Category
            builder.HasOne(e => e.Category)
                .WithMany(v => v.Products)
                .IsRequired(false)
                .HasForeignKey(e => e.CategoryId);

        }
    }
}
