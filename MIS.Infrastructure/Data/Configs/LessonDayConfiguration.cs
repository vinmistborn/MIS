using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MIS.Domain.Entities;

namespace MIS.Infrastructure.Data.Configs
{
    public class LessonDayConfiguration : IEntityTypeConfiguration<LessonDay>
    {
        public void Configure(EntityTypeBuilder<LessonDay> builder)
        {
            builder.Property(p => p.DayOfWeek)                   
                   .IsRequired();
        }
    }
}
