using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mttechne.Backend.Junior.Services.Model;

namespace Mttechne.Backend.Junior.Services.Mapping
{
    internal class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
               .Property(x => x.Name)
               .HasColumnType("NVARCHAR")
               .HasMaxLength(80)
               .IsRequired();

            builder
               .Property(x => x.Price)
               .HasPrecision(10, 2);
        }
    }
}
