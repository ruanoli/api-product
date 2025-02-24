using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.Data.Mappings
{
    internal class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id);
            builder.Property(x => x.LastUpdateDate);
            builder.Property(x => x.Quantity);
            builder.Property(x => x.RegisterDate);
            builder.Property(x => x.Total).HasColumnType("decimal(18,2)");

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500);

            builder.Property(x => x.Price).HasColumnType("decimal(18,2)");
        }
    }
}
