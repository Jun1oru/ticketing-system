using System.ComponentModel.DataAnnotations;
using Core.Enums;

namespace API.DTOs;

public class CreateTicketDto
{
    [Required]
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    [Required]
    public TicketStatus? Status { get; set; }

    [Required]
    public TicketPriority? Priority { get; set; }
}
