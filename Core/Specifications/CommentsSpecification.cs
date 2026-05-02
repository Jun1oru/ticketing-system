using Core.Entities;

namespace Core.Specifications;

public class CommentsSpecification : BaseSpecification<Comment>
{
    public CommentsSpecification(int? ticketId) : base(x =>
        x.TicketId == ticketId || ticketId == null
    )
    {
    }
}
