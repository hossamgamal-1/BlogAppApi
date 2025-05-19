using BlogAppApi.Core;
using BlogAppApi.Models;
using System.ComponentModel.DataAnnotations;

namespace BlogAppApi.Features.BlogFeature.Models;

public class PostComment : BaseModel
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public Post Post { get; set; } = null!;
    public required string AppUserId { get; set; }
    public AppUser AppUser { get; set; } = null!;

    public int ParentId { get; set; }
    public PostComment Parent { get; set; } = null!;

    public ICollection<PostComment> Replies { get; set; } = [];

    [MaxLength(500)]
    public required string Body { get; set; }
}