
using System.Text.Json;
using System.Text.Json.Serialization;
using Core.Entities;

namespace Infrastructure.Data;

public class AppDbContextSeed
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        Converters = { new JsonStringEnumConverter() }
    };

    public static async Task SeedAsync(AppDbContext context)
    {
        if (!context.Tickets.Any())
        {
            var ticketsData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/tickets.json");

            var tickets = JsonSerializer.Deserialize<List<Ticket>>(ticketsData, JsonOptions);

            if (tickets == null) return;

            tickets.ForEach(t => { t.CreatedAt = DateTime.UtcNow; t.UpdatedAt = DateTime.UtcNow; });

            context.Tickets.AddRange(tickets);

            await context.SaveChangesAsync();
        }

        if (!context.Comments.Any())
        {
            var commentsData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/comments.json");

            var comments = JsonSerializer.Deserialize<List<Comment>>(commentsData, JsonOptions);

            if (comments == null) return;

            comments.ForEach(c => { c.CreatedAt = DateTime.UtcNow; c.UpdatedAt = DateTime.UtcNow; });

            context.Comments.AddRange(comments);

            await context.SaveChangesAsync();
        }
    }
}
