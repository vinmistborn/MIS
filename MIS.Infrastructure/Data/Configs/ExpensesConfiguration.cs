using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MIS.Domain.Entities;
using System;

namespace MIS.Infrastructure.Data.Configs
{
    public class ExpensesConfiguration : IEntityTypeConfiguration<Expenses>
    {
        public void Configure(EntityTypeBuilder<Expenses> builder)
        {
            builder.Property(p => p.Date)
                   .HasDefaultValueSql("getdate()");
            builder.Property(p => p.Amount)
                   .HasColumnType("decimal(10, 2)")
                   .IsRequired();
            builder.Property(p => p.PaymentType)
                   .IsRequired();
            builder.Property(p => p.Comment)
                   .IsRequired();
            builder.HasOne(p => p.Branch)
                   .WithMany(p => p.Expenses)
                   .OnDelete(DeleteBehavior.SetNull);
            builder.Property(p => p.Item)
                   .HasMaxLength(100)
                   .IsRequired();            
        }
    }
}
