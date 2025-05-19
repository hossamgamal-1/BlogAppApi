using BlogAppApi.Core;
using BlogAppApi.Models;
using System.ComponentModel.DataAnnotations;

namespace BlogAppApi.Features.Blog.Models;

public class Post : BaseModel
{
    public int Id { get; set; }

    [MaxLength(500)]
    public required string Body { get; set; }

    public int BlogId { get; set; }
    public Blog Blog { get; set; } = null!;
    public required string AppUserId { get; set; }
    public AppUser AppUser { get; set; } = null!;

    public ICollection<PostLike> Likes { get; set; } = [];

    public ICollection<PostComment> Comments { get; set; } = [];
}