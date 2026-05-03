using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace API.DTOs.Comments;

public class UpdateCommentDto
{
    [Required]
    [MaxLength(Comment.BodyMaxLength)]
    public string? Body { get; set; }
}
