using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MIS.Domain.Entities.AuditLogging;

namespace MIS.Infrastructure.Data.Configs
{
    public class IncomeLogConfiguration : IEntityTypeConfiguration<IncomeLog>
    {
        public void Configure(EntityTypeBuilder<IncomeLog> builder)
        {
            builder.Property(x => x.Amount)
                   .HasColumnType("decimal(10, 2)");
        }
    }
}
