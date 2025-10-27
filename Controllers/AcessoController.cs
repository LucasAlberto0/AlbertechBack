using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[Controller]")]

public class AcessoController : ControllerBase
{
    /// <summary>
    /// Verifica se o token de acesso é válido 
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a autenticação seja realizada com sucesso</response>
    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok("Acesso permitido!");
    }
}