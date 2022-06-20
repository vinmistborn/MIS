using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MIS.Domain.Entities;

namespace MIS.Infrastructure.Data.Configs
{
    public class GroupTimeConfiguration : IEntityTypeConfiguration<GroupTime>
    {
        public void Configure(EntityTypeBuilder<GroupTime> builder)
        {
            builder.Property(p => p.Time)
                   .HasMaxLength(20)
                   .IsRequired(); 
        }
    }
}
