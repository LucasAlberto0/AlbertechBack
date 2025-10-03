using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[Controller]")]

public class AcessoController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Acesso permitido!");
    }
}