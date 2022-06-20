using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MIS.Domain.Entities;

namespace MIS.Infrastructure.Data.Configs
{
    public class StudentGroupHistoryConfiguration : IEntityTypeConfiguration<StudentGroupHistory>
    {
        public void Configure(EntityTypeBuilder<StudentGroupHistory> builder)
        {
            builder.Property(p => p.IsActive)
                   .IsRequired();
        }
    }
}
