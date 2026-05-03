using System.ComponentModel.DataAnnotations;
using Core.Entities;
using Core.Enums;

namespace API.DTOs.Tickets;

public class CreateTicketDto
{
    [Required]
    [MaxLength(Ticket.TitleMaxLength)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(Ticket.DescriptionMaxLength)]
    public string? Description { get; set; }

    [Required]
    public TicketStatus? Status { get; set; }

    [Required]
    public TicketPriority? Priority { get; set; }
}
