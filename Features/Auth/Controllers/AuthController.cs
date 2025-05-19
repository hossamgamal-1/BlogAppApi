using BlogAppApi.Core;
using BlogAppApi.Features.Auth.Dtos;
using BlogAppApi.Features.Auth.Services;
using BlogAppApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppApi.Features.Auth.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService authService,UserManager<AppUser> userManager) : AppController(userManager)
{
    private readonly IAuthService _authService = authService;

    [HttpPost("Register")]
    public async Task<ActionResult<AuthResponseDto>> RegisterAsync(RegisterRequestDto dto)
    {
        return await Handle(() => _authService.RegisterUserAsync(dto));
    }

    [HttpPost("Login")]
    public async Task<ActionResult<AuthResponseDto>> LoginAsync(LoginRequestDto dto) => await Handle(() => _authService.LoginAsync(dto));

    [Authorize]
    [HttpPost("ChangePassword")]
    public async Task<ActionResult<string>> ChangePasswordAsync(ChangePasswordDto dto)
    {
        return await Handle(async () => {
            await _authService.ChangePasswordAsync(GetToken(),dto);
            return "Password changed successfully";
        });
    }
}