using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class GerenteController : ControllerBase
{
    private readonly IGerenteInterface _gerenteInterface;

    public GerenteController(IGerenteInterface gerenteInterface)
    {
        _gerenteInterface = gerenteInterface;
    }

    [HttpPost("Cadastro")]
    [AllowAnonymous]
    public async Task<ActionResult<ResponseModel<GerenteModel>>> CadastrarGerente(CadastroGerenteDto dto)
    {
        var resposta = await _gerenteInterface.CadastroGerente(dto);

        if (!resposta.Status)
            return BadRequest(resposta);

        return CreatedAtAction(nameof(LoginGerente), resposta);
    }

    [HttpPost("Login")]
    [AllowAnonymous]
    public async Task<ActionResult<ResponseModel<string>>> LoginGerente(LoginGerenteDto dto)
    {
        var resposta = await _gerenteInterface.LoginGerente(dto);

        if (!resposta.Status)
            return Unauthorized(resposta);

        return Ok(resposta);
    }

    [HttpGet("Dados")]
    [Authorize]
    public async Task<ActionResult<ResponseModel<GerenteDashboardDto>>> ObterDashboard()
    {
        var resposta = await _gerenteInterface.ObterDashboard();

        if (!resposta.Status)
            return NotFound(resposta);

        return Ok(resposta);
    }
}
