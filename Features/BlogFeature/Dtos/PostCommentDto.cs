using BlogAppApi.Features.BlogFeature.Models;
using BlogAppApi.Models;
using System.ComponentModel.DataAnnotations;

namespace BlogAppApi.Features.BlogFeature.Dtos;

public class PostCommentDto

{
    public int Id { get; set; }
    public AppUser AppUser { get; set; } = null!;

    public PostComment Parent { get; set; } = null!;

    public ICollection<PostCommentDto> Replies { get; set; } = [];

    [MaxLength(500)]
    public required string Body { get; set; }

    // FromPostComment method
    public static PostCommentDto FromPostComments(PostComment postComment)
    {
        return new PostCommentDto {
            Id = postComment.Id,
            AppUser = postComment.AppUser,
            Parent = postComment.Parent,
            Replies = postComment.Replies.Select(PostCommentDto.FromPostComments).ToList(),
            Body = postComment.Body
        };
    }
}