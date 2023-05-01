using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Infra.Data.EntitiesConfigutation
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(o => o.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasData(
                new Category(1, "Eletronic"),
                new Category(2, "Sports"),
                new Category(3, "Courses")
                );
        }
    }
}
