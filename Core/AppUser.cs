using BlogAppApi.Features.Auth.Dtos;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BlogAppApi.Models;

public class AppUser : IdentityUser
{
    [MaxLength(100)]
    public required string FullName { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    public static AppUser FromRegisterDto(RegisterRequestDto dto)
    {
        return new AppUser {
            FullName = dto.FullName,
            UserName = dto.UserName,
            Email = dto.Email,
            CreatedAt = DateTime.UtcNow,
        };
    }
}