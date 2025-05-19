using BlogAppApi.Features.BlogFeature.Models;
using BlogAppApi.Models;

namespace BlogAppApi.Features.BlogFeature.Dtos;

public class PostLikeDto
{
    public int Id { get; set; }
    public AppUser AppUser { get; set; } = null!;

    // FromPostLike method
    public static PostLikeDto FromPostLike(PostLike postLike)
    {
        return new PostLikeDto
        {
            Id = postLike.Id,
            AppUser = postLike.AppUser
        };
    }
}
