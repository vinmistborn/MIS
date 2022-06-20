using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MIS.Domain.Entities;
using MIS.Domain.Entities.Identity;
using MIS.Domain.Enums;

namespace MIS.Infrastructure.Data.Configs
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.FirstName)
                   .IsRequired();
            builder.Property(p => p.LastName)
                   .IsRequired();
            builder.Property(p => p.DoB)
                   .IsRequired();
            builder.Property(p => p.EmployeeStatus)
                   .HasDefaultValue(EmployeeStatus.Active);
            builder.HasOne(p => p.Branch)
                    .WithOne(p => p.Manager)
                    .HasForeignKey<Branch>(p => p.ManagerId)
                    .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
