using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WpfChallenge.Domain.Entities;

namespace WpfChallenge.Data.Infra.Repositories.Map
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            ////Propriedades
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("VARCHAR(255)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("VARCHAR(255)").IsRequired();
            builder.Property(x => x.Phone).HasColumnType("VARCHAR(20)").IsRequired();
            builder.Property(x => x.Street).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(x => x.Number).HasColumnType("VARCHAR(10)");
            builder.Property(x => x.Neighborhood).HasColumnType("VARCHAR(255)");
            builder.Property(x => x.City).HasColumnType("VARCHAR(255)");
            builder.Property(x => x.State).HasColumnType("VARCHAR(255)");
            builder.Property(x => x.Country).HasColumnType("VARCHAR(255)");
            builder.Property(x => x.ZipCode).HasColumnType("VARCHAR(255)");
        }
    }
}
