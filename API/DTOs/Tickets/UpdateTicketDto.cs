using System.ComponentModel.DataAnnotations;
using Core.Entities;
using Core.Enums;

namespace API.DTOs.Tickets;

public class UpdateTicketDto
{
    [Required]
    [MaxLength(Ticket.TitleMaxLength)]
    public string? Title { get; set; }

    [MaxLength(Ticket.DescriptionMaxLength)]
    public string? Description { get; set; }

    [Required]
    public TicketStatus? Status { get; set; }

    [Required]
    public TicketPriority? Priority { get; set; }
}
