using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RaizenUserRegister.Domain.Aggregates;

namespace RaizenUserRegister.Infra.Data.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable(name: nameof(Address));
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasMaxLength(36)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(x => x.street).HasMaxLength(250).IsRequired();
            builder.Property(x => x.zipCode).IsRequired();
            builder.Property(x => x.number).IsRequired();
            builder.Property(x => x.neighborhood).IsRequired(false);
            builder.Property(x => x.state).IsRequired(false);
            builder.Property(x => x.city).IsRequired(false);
            builder.Property(x => x.complement).IsRequired(false);
            
        }
    }
}
