using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Infra.Data.EntitiesConfigutation
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(o => o.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(o => o.Description)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(o => o.Price)
                .HasPrecision(10, 2);

            builder.HasOne(o => o.Category)
                .WithMany(o => o.Products)
                .HasForeignKey(o => o.CategoryId);
        }
    }
}
