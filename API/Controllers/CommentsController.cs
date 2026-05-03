using API.DTOs.Comments;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/tickets/{ticketId:int}/[controller]")]
public class CommentsController(IGenericRepository<Comment> repo, IGenericRepository<Ticket> ticketRepo) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<CommentDto>>> GetCommentsForTicket(int ticketId)
    {
        if (!ticketRepo.Exists(ticketId))
            return NotFound("Ticket not found");

        var spec = new CommentsSpecification(ticketId);

        var comments = await repo.ListAsync(spec);

        var commentsDtos = comments.Select(MapToDto).ToList();

        return Ok(commentsDtos);
    }

    [HttpPost]
    public async Task<ActionResult<CommentDto>> CreateComment(CreateCommentDto createCommentDto, int ticketId)
    {
        if (!ticketRepo.Exists(ticketId))
            return NotFound("Ticket not found");

        var comment = new Comment
        {
            Body = createCommentDto.Body,
            TicketId = ticketId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        repo.Add(comment);

        await repo.SaveChangesAsync();

        var commentDto = MapToDto(comment);

        return commentDto;
    }

    private static CommentDto MapToDto(Comment comment) => new()
    {
        Id = comment.Id,
        CreatedAt = comment.CreatedAt,
        UpdatedAt = comment.UpdatedAt,
        Body = comment.Body,
        TicketId = comment.TicketId
    };
}
