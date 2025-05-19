using BlogAppApi.Core;
using System.ComponentModel.DataAnnotations;

namespace BlogAppApi.Features.Blog.Models;

public class Blog : BaseModel
{
    public int Id { get; set; }

    [MaxLength(100)]
    public required string Title { get; set; }

    [MaxLength(20)]
    public BlogStatus Status { get; set; }

    public ICollection<Post> Posts { get; set; } = [];
}

public enum BlogStatus
{
    Draft,
    Published,
    Archived
}