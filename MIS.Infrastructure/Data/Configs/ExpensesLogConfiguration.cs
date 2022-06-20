using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MIS.Domain.Entities.AuditLogging;

namespace MIS.Infrastructure.Data.Configs
{
    public class ExpensesLogConfiguration : IEntityTypeConfiguration<ExpensesLog>
    {
        public void Configure(EntityTypeBuilder<ExpensesLog> builder)
        {
            builder.Property(x => x.Amount)
                   .HasColumnType("decimal(10, 2)");
        }
    }
}
