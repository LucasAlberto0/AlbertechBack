using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[Controller]")]

public class GerenteController : ControllerBase
{

    private GerenteService _gerenteService;
    public GerenteController(GerenteService gerenteService)
    {
        _gerenteService = gerenteService;
    }

    [HttpPost("Cadastro")]
    public async Task<IActionResult> CadastroGerente(CadastroGerenteDto dto)
    {
        await _gerenteService.CadastroGerente(dto);
        return Ok();
    }

    [HttpPost("Login")]
    public async Task<IActionResult> LoginGerente(LoginGerenteDto dto)
    {
        var token = await _gerenteService.LoginGerente(dto);
        return Ok(new { token });
    }

    [HttpGet("Dados")]
    public async Task<IActionResult> ObterDashboard()
    {
        try
        {
            var dadosGerente = await _gerenteService.ObterDadosGerente();
            return Ok(dadosGerente);
        }
        catch (Exception ex)
        {
            return Unauthorized(new { mensagem = ex.Message });
        }
    }
}