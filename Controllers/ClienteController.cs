using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


[Authorize]
[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private readonly IClienteInterface _clienteInterface;

    public ClienteController(IClienteInterface clienteInterface)
    {
        _clienteInterface = clienteInterface;
    }

    /// <summary>
    /// Cria um cliente do gerente
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="401">Caso o token seja inválido</response>
    /// <response code="400">Caso a criação do cliente não seja realizada com sucesso</response>
    /// <response code="201">Caso o cliente seja criado com sucesso</response>
    [HttpPost("CriarCliente")]
    public async Task<ActionResult<ResponseModel<ClienteModel>>> CriarClientes(ClienteCriacaoDto clienteCriacaoDto)
    {
        var resposta = await _clienteInterface.CriarCliente(clienteCriacaoDto);

        if (!resposta.Status)
            return BadRequest(resposta);

        return CreatedAtAction(nameof(ListarClientes), resposta);
    }

    /// <summary>
    /// Cria uma lista com todos os clientes do gerente
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="401">Caso o token seja inválido</response>
    /// <response code="404">Caso a lista não retorne nada</response>
    /// <response code="200">Caso a lista de clientes do gerente seja gerada com sucesso</response>
    [HttpGet("ListarClientes")]
    public async Task<ActionResult<ResponseModel<ClienteModel>>> ListarClientes()
    {
        var resposta = await _clienteInterface.ListarClientes();

        if (!resposta.Status)
            return NotFound(resposta);

        return Ok(resposta);
    }

    /// <summary>
    /// Edita um cliente do gerente
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="401">Caso o token seja inválido</response>
    /// <response code="400">Caso a edição falhar</response>
    /// <response code="200">Caso a edição seja realizada com sucesso</response>
    [HttpPut("EditarCliente")]
    public async Task<ActionResult<ResponseModel<ClienteModel>>> EditarCliente(ClienteEdicaoDto clienteEdicaoDto)
    {

        var resposta = await _clienteInterface.EditarCliente(clienteEdicaoDto);

        if (!resposta.Status)
            return BadRequest(resposta);

        return Ok(resposta);
    }

    /// <summary>
    /// Deleta um cliente do gerente
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="401">Caso o token seja inválido</response>
    /// <response code="404">Caso não encontre o cliente do gerente</response>
    /// <response code="204">Caso o cliente seja deletado com sucesso</response>
    [HttpDelete("DeletarCliente")]
    public async Task<ActionResult<ResponseModel<ClienteModel>>> DeletarCliente(int idCliente)
    {
        var resposta = await _clienteInterface.DeletarCliente(idCliente);

        if (!resposta.Status)
            return NotFound(resposta);
        
        return NoContent();
    }
}