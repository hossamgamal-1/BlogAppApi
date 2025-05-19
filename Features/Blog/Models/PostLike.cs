using BlogAppApi.Models;

namespace BlogAppApi.Features.Blog.Models;

public class PostLike
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public Post Post { get; set; } = null!;
    public required string AppUserId { get; set; }
    public AppUser AppUser { get; set; } = null!;
}