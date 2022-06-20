using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MIS.Domain.Entities;

namespace MIS.Infrastructure.Data.Configs
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.Property(p => p.Code)
                   .HasMaxLength(10)
                   .IsRequired();
            builder.Property(p => p.Capacity)
                   .IsRequired();
            builder.HasOne(p => p.Branch)
                   .WithMany(p => p.Rooms)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
