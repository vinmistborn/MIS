using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MIS.Domain.Entities;

namespace MIS.Infrastructure.Data.Configs
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(p => p.FirstName)
                   .IsRequired();
            builder.Property(p => p.LastName)
                   .IsRequired();
            builder.Property(p => p.DoB)
                   .IsRequired();
            builder.Property(p => p.PhoneNumber)
                    .HasMaxLength(20)
                    .IsRequired();
            builder.Property(p => p.IsActive)
                    .IsRequired();
        }
    }
}
