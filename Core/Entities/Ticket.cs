using Core.Enums;

namespace Core.Entities;

public class Ticket : BaseEntity
{
    public required string Title { get; set; }
    public string? Description { get; set; }
    public required TicketStatus Status { get; set; }
    public required TicketPriority Priority { get; set; }
}
