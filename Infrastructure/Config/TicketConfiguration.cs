using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.Property(t => t.Status)
            .HasConversion<string>()
            .HasMaxLength(20);
        builder.Property(t => t.Priority)
            .HasConversion<string>()
            .HasMaxLength(20);
    }
}
