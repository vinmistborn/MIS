using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MIS.Domain.Entities;

namespace MIS.Infrastructure.Data.Configs
{
    public class TotalCashFlowConfiguration : IEntityTypeConfiguration<TotalCashFlow>
    {
        public void Configure(EntityTypeBuilder<TotalCashFlow> builder)
        {
            builder.Property(p => p.Amount)
                   .HasColumnType("decimal(18, 2)");
            builder.Property(p => p.BranchId)
                    .IsRequired();
            builder.Property(p => p.Amount)
                    .IsRequired();
            builder.Property(p => p.DateTime)
                    .IsRequired();
        }
    }
}
