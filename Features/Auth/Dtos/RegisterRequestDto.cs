namespace BlogAppApi.Features.Auth.Dtos;

public class RegisterRequestDto : LoginRequestDto
{
    public required string FullName { get; set; }
    public required string UserName { get; set; }
}