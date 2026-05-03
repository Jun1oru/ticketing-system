using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Comments;

public class CreateCommentDto
{
    [Required]
    public string Body { get; set; } = string.Empty;
}
