using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Comment : BaseEntity
{
    public const int BodyMaxLength = 512;

    [MaxLength(BodyMaxLength)]
    public required string Body { get; set; }
    public int TicketId { get; set; }
}
