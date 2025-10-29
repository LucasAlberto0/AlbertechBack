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

    /// <summary>
    /// Cria um gerente
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso a criação do gerente seja realizada com sucesso</response>
    [HttpPost("Cadastro")]
    [AllowAnonymous]
    public async Task<ActionResult<ResponseModel<GerenteModel>>> CadastrarGerente(CadastroGerenteDto dto)
    {
        var resposta = await _gerenteInterface.CadastroGerente(dto);

        if (!resposta.Status)
            return BadRequest(resposta);

        return CreatedAtAction(nameof(LoginGerente), resposta);
    }

    /// <summary>
    /// Acesso do gerente gerando o token de acesso
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="401">Caso o acesso do gerente seja negado</response>
    /// <response code="200">Caso o acesso do gerente seja realizado com sucesso</response>
    [HttpPost("Login")]
    [AllowAnonymous]
    public async Task<ActionResult<ResponseModel<string>>> LoginGerente(LoginGerenteDto dto)
    {
        var resposta = await _gerenteInterface.LoginGerente(dto);

        if (!resposta.Status)
            return Unauthorized(resposta);

        return Ok(resposta);
    }

    /// <summary>
    /// Edita as informações do gerente
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="401">Caso o token seja inválido</response>
    /// <response code="400">Caso a edição falhar</response>
    /// <response code="200">Caso a edição seja realizada com sucesso</response>
    [Authorize]
    [HttpPut("Editar")]
    public async Task<ActionResult<ResponseModel<GerenteModel>>> EditarGerente([FromBody] GerenteEdicaoDto dto)
    {
        var resposta = await _gerenteInterface.EditarGerente(dto);

        if (!resposta.Status)
            return BadRequest(resposta);
        return Ok(resposta);
    }

    /// <summary>
    /// Acessa os dados do gerente e a quantidade de clientes ativos.
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="401">Caso o token seja inválido</response>
    /// /// <response code="404">Caso o acesso aos dados do gerente retorne nada</response>
    /// <response code="200">Caso o acesso aos dados do gerente seja realizado com sucesso</response>
    [HttpGet("Dados")]
    [Authorize]
    public async Task<ActionResult<ResponseModel<GerenteDadosDto>>> ObterDadosDoGerente()
    {
        var resposta = await _gerenteInterface.ObterDadosDoGerente();

        if (!resposta.Status)
            return NotFound(resposta);

        return Ok(resposta);
    }
}
