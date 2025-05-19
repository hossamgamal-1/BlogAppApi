using BlogAppApi.Features.BlogFeature.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogAppApi.Features.BlogFeature.Dtos;

public class BlogDto
{
    [NotMapped]
    public int Id { get; set; }

    public required string Title { get; set; }

    public ICollection<PostDto> Posts { get; set; } = [];

    // FromBlog method
    public static BlogDto FromBlog(Blog blog)
    {
        return new BlogDto
        {
            Id = blog.Id,
            Title = blog.Title,
            Posts = blog.Posts.Select(PostDto.FromPost).ToList()
        };
    }
}