using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RaizenUserRegister.Domain.Aggregates;

namespace RaizenUserRegister.Infra.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .ValueGeneratedNever()
               .HasMaxLength(36)
               .IsRequired();

            builder.Property(x => x.name).HasMaxLength(150).IsRequired();
            builder.Property(x => x.secondName).HasMaxLength(150).IsRequired();


            builder.HasOne(x => x.address)
                .WithOne(b => b.user)
                .HasForeignKey<Address>(b => b.userId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
