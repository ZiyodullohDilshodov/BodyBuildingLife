using System.ComponentModel.DataAnnotations;

namespace BodyBuildingLife.Service.DTOs.Login;

public  class LoginDto
{
    [Required]
    public string Email { get; set; }
}
