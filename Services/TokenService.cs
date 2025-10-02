using System.Security.Claims;

public class TokenService
{
    private IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(GerenteModel gerente)
    {
        Claim[] claims = new Claim[]{
            // new Claim("id", gerente.Id),
            new Claim("nome", gerente.Nome),
            new Claim("email", gerente.Email),
            new Claim(ClaimTypes.DateOfBirth, gerente.DataNascimento.ToString()),
            new Claim("loginTimestamp", DateTime.UtcNow.ToString())
        };
    }
}