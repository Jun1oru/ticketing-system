using System.ComponentModel.DataAnnotations;
using Core.Enums;

namespace Core.Entities;

public class Ticket : BaseEntity
{
    public const int TitleMaxLength = 128;
    public const int DescriptionMaxLength = 256;
    
    [MaxLength(TitleMaxLength)]
    public required string Title { get; set; }

    [MaxLength(DescriptionMaxLength)]
    public string? Description { get; set; }

    public required TicketStatus Status { get; set; }

    public required TicketPriority Priority { get; set; }
}
