using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MIS.Domain.Entities;
using System;

namespace MIS.Infrastructure.Data.Configs
{
    public class IncomeConfiguration : IEntityTypeConfiguration<Income>
    {
        public void Configure(EntityTypeBuilder<Income> builder)
        {
            builder.Property(p => p.Date)
                   .HasDefaultValueSql("getdate()");
            builder.Property(p => p.Amount)
                   .HasColumnType("decimal(10, 2)")
                   .IsRequired();
            builder.Property(p => p.PaymentType)
                   .IsRequired();
            builder.HasOne(p => p.Branch)
                   .WithMany(p => p.Incomes)
                   .OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(p => p.Student)
                   .WithMany(p => p.Payments)
                   .OnDelete(DeleteBehavior.SetNull);        
        }
    }
}
