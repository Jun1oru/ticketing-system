using API.DTOs.Tickets;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketsController(IGenericRepository<Ticket> repo) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<TicketDto>>> GetTickets()
    {
        var tickets = await repo.GetAllAsync();

        var ticketDtos = tickets.Select(MapToDto).ToList();

        return Ok(ticketDtos);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TicketDto>> GetTicketById(int id)
    {
        var ticket = await repo.GetByIdAsync(id);

        if (ticket == null) return NotFound();

        var ticketDto = MapToDto(ticket);

        return ticketDto;
    }

    [HttpPost]
    public async Task<ActionResult<TicketDto>> CreateTicket(CreateTicketDto createTicketDto)
    {
        var ticket = new Ticket
        {
            Title = createTicketDto.Title,
            Description = createTicketDto.Description,
            Status = createTicketDto.Status!.Value,
            Priority = createTicketDto.Priority!.Value,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        repo.Add(ticket);

        await repo.SaveChangesAsync();

        var ticketDto = MapToDto(ticket);
        return CreatedAtAction(nameof(GetTicketById), new { id = ticket.Id }, ticketDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateTicket(int id, UpdateTicketDto updateTicketDto)
    {
        var ticket = await repo.GetByIdAsync(id);

        if (ticket == null) return NotFound();

        ticket.Title = updateTicketDto.Title!;
        ticket.Description = updateTicketDto.Description;
        ticket.Status = updateTicketDto.Status!.Value;
        ticket.Priority = updateTicketDto.Priority!.Value;
        ticket.UpdatedAt = DateTime.UtcNow;

        repo.Update(ticket);

        await repo.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteTicket(int id)
    {
        var ticket = await repo.GetByIdAsync(id);

        if (ticket == null) return NotFound();

        repo.Delete(ticket);

        await repo.SaveChangesAsync();

        return NoContent();
    }

    private static TicketDto MapToDto(Ticket ticket) => new()
    {
        Id = ticket.Id,
        CreatedAt = ticket.CreatedAt,
        UpdatedAt = ticket.UpdatedAt,
        Title = ticket.Title,
        Description = ticket.Description,
        Status = ticket.Status,
        Priority = ticket.Priority
    };
}
