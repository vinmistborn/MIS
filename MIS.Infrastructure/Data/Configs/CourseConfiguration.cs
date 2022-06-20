using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MIS.Domain.Entities;

namespace MIS.Infrastructure.Data.Configs
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(p => p.Name)
                   .HasMaxLength(30)
                   .IsRequired();
            builder.Property(p => p.Fee)
                   .HasColumnType("decimal(10, 2)")
                   .IsRequired();
            builder.Property(p => p.CourseDuration)
                   .HasMaxLength(10)
                   .IsRequired();
            builder.Property(p => p.CourseLevel)
                   .HasMaxLength(20)
                   .IsRequired();                    
        }
    }
}
