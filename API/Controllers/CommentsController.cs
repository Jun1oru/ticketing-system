using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentsController(IGenericRepository<Comment> repo, IGenericRepository<Ticket> ticketRepo) : ControllerBase
{
    [HttpGet("{ticketId:int}")]
    public async Task<ActionResult<IReadOnlyList<Comment>>> GetCommentsForTicket(int ticketId)
    {
        var spec = new CommentsSpecification(ticketId);

        var comments = await repo.ListAsync(spec);

        return Ok(comments);
    }

    [HttpPost]
    public async Task<ActionResult<Comment>> CreateComment(Comment comment)
    {
        if (!ticketRepo.Exists(comment.TicketId))
            return NotFound("Ticket not found");

        repo.Add(comment);

        await repo.SaveChangesAsync();

        return comment;
    }
}
