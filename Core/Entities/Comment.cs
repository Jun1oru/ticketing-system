namespace Core.Entities;

public class Comment : BaseEntity
{
    public required string Body { get; set; }
    public int TicketId { get; set; }
}
