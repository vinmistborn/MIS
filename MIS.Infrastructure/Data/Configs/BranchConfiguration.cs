using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MIS.Domain.Entities;

namespace MIS.Infrastructure.Data.Configs
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.Property(p => p.District)
                   .HasMaxLength(30)
                   .IsRequired();
            builder.Property(p => p.Address)
                   .HasMaxLength(30)
                   .IsRequired();
            builder.Property(p => p.PhoneNumber)
                   .HasMaxLength(15)
                   .IsRequired();
        }
    }
}
