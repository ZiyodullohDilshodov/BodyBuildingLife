using BodyBuildingLife.Service.DTOs.Login;

namespace BodyBuildingLife.Service.Interfaces.Auth;

public  interface IAuthService
{
    public Task<LoginForResultDto>AuthentificateAsync(LoginDto loginDto);
}
