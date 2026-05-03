using System.ComponentModel.DataAnnotations;
using Core.Enums;

namespace API.DTOs.Tickets;

public class UpdateTicketDto
{
    [Required]
    public string? Title { get; set; }

    public string? Description { get; set; }

    [Required]
    public TicketStatus? Status { get; set; }

    [Required]
    public TicketPriority? Priority { get; set; }
}
