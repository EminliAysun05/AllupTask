using Academy.AuthenticationService.Model;

namespace Core.Security.Jwt.Contracts;

public interface IJwtAuthService
{
    Task<JwtTokenResponseModel> CreateToken(JwtTokenRequestModel model);
}
