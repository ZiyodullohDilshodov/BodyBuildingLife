using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using BodyBuildingLife.Service.DTOs.Login;
using BodyBuildingLife.Service.Exceptions;
using BodyBuildingLife.Service.DTOs.Person;
using BodyBuildingLife.Service.Interfaces.Auth;
using BodyBuildingLife.Service.Interfaces.Person;

namespace BodyBuildingLife.Service.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly IPersonService _personService;

    public AuthService(IPersonService personService , IConfiguration configuration)
    {
        _personService = personService;
        _personService = personService;
    }

    public async Task<LoginForResultDto> AuthentificateAsync(LoginDto loginDto)
    {
        var person = await _personService.RtrieveByEmaiil(loginDto.Email);

        if (person is null)
            throw new BodyBuildingLifeException(404, "Person is not found");

        return new LoginForResultDto
        {
            Token = GenerateToken(person)
        };

    }

    private string GenerateToken(PersonForResultDto user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                 new Claim("Id", user.Id.ToString()),
                 new Claim(ClaimTypes.Name, user.FirstName),
                 new Claim(ClaimTypes.Email, user.Email)
                 // To Do  : Role logic 

            }),
            Audience = _configuration["JWT:Audience"],
            Issuer = _configuration["JWT:Issuer"],
            IssuedAt = DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddMinutes(double.Parse(_configuration["JWT:Expire"])),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
