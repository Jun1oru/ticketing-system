using System.ComponentModel.DataAnnotations;
using Core.Entities;
using Core.Enums;

namespace API.DTOs.Tickets;

public class TicketDto
{
    public int Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    [MaxLength(Ticket.TitleMaxLength)]
    public required string Title { get; set; }

    [MaxLength(Ticket.DescriptionMaxLength)]
    public string? Description { get; set; }
    public required TicketStatus Status { get; set; }
    public required TicketPriority Priority { get; set; }
}
