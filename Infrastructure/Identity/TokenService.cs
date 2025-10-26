using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

public class TokenService
{
    private IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(GerenteModel gerente)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, gerente.Id.ToString()), 
            new Claim(ClaimTypes.Name, gerente.Nome),
            new Claim(ClaimTypes.Email, gerente.Email),
            new Claim("loginTimestamp", DateTime.UtcNow.ToString("o"))
        };

        var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("5424h32ljh23lk4j234234324")); 
        var signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            expires: DateTime.UtcNow.AddMinutes(120),
            claims: claims,
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
