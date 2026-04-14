using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IConfiguration config) : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        if(request.Email!="aziz@gmail.com" || request.Password!="123456")
            return Unauthorized();

            var token=GenerateToken(request.Email);
            return Ok(new {token});
    }

    private object GenerateToken(string email)
    {
        var claims = new[]
        {
          new Claim(ClaimTypes.Name,email)  
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(config["Jwt:Key"])
        );

        var cerds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
                issuer:config["Jwt:Issuer"],
                audience:config["Jwt:Audience"],
                claims:claims,
                expires:DateTime.Now.AddMinutes(60),
                signingCredentials:cerds
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}