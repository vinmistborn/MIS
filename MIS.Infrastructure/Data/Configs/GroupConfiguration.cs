using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MIS.Domain.Entities;

namespace MIS.Infrastructure.Data.Configs
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.Property(p => p.Fee)
                   .HasColumnType("decimal(10, 2)")
                   .IsRequired();
            builder.HasOne(p => p.GroupType)
                    .WithMany(p => p.Groups)
                    .OnDelete(DeleteBehavior.SetNull);
            builder.Property(p => p.Capacity)
                   .IsRequired();
            builder.Property(p => p.IsActive)                    
                    .IsRequired();
            builder.HasOne(p => p.Course)
                   .WithMany(p => p.Groups)
                   .OnDelete(DeleteBehavior.Restrict);                      
            builder.HasMany(p => p.Teachers)
                   .WithMany(p => p.Groups)
                   .UsingEntity<GroupTeacher>(
                    j => j.HasOne(m => m.Teacher).WithMany(g => g.GroupTeachers),
                    j => j.HasOne(m => m.Group).WithMany(g => g.GroupTeachers));
        }
    }
}
