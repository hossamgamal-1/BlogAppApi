using BlogAppApi.Core;
using BlogAppApi.Features.BlogFeature.Models;
using System.ComponentModel.DataAnnotations;

namespace BlogAppApi.Features.BlogFeature.Dtos;

public class PostDto
{
    public int Id { get; set; }

    [MaxLength(500)]
    public required string Body { get; set; }

    public ICollection<PostLikeDto> Likes { get; set; } = [];

    public ICollection<PostCommentDto> Comments { get; set; } = [];

    // FromPost method
    public static PostDto FromPost(Post post)
    {
        return new PostDto {
            Id = post.Id,
            Body = post.Body,
            Likes = post.Likes.Select(PostLikeDto.FromPostLike).ToList(),
            Comments = post.Comments.Select(PostCommentDto.FromPostComments).ToList(),
        };
    }
}