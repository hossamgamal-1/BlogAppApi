using BlogAppApi.Features.Auth.Dtos;

namespace BlogAppApi.Features.Auth.Services;

public interface IAuthService
{
    Task<AuthResponseDto> RegisterUserAsync(RegisterRequestDto dto);

    Task<AuthResponseDto> LoginAsync(LoginRequestDto dto);

    Task ChangePasswordAsync(string token, ChangePasswordDto dto);
}