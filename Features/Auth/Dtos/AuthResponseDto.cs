using BlogAppApi.Models;

namespace BlogAppApi.Features.Auth.Dtos;

public class AuthResponseDto
{
    public required string FullName { get; set; }
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public required string Token { get; set; }

    public static AuthResponseDto FromUser(AppUser user,string token)
    {
        return new AuthResponseDto {
            FullName = user.FullName,
            UserName = user.UserName!,
            Email = user.Email!,
            Token = token
        };
    }
}