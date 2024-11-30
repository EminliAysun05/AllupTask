namespace Academy.AuthenticationService.Model;

public class JwtTokenRequestModel
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }
    public List<string> Roles { get; set; } = [];
}