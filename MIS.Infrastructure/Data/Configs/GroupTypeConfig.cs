using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MIS.Domain.Entities;

namespace MIS.Infrastructure.Data.Configs
{
    public class GroupTypeConfig : IEntityTypeConfiguration<GroupType>
    {
        public void Configure(EntityTypeBuilder<GroupType> builder)
        {
            builder.Property(p => p.IncreaseFeeBy)
                    .HasColumnType("decimal(3,2)")
                    .IsRequired();
            builder.Property(p => p.Type)
                    .HasMaxLength(20)
                    .IsRequired();
        }
    }
}
