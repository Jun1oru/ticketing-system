using System;

namespace API.DTOs.Comments;

public class CommentDto
{
    public int Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public required string Body { get; set; }
    public int TicketId { get; set; }
}
