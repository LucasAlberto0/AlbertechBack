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

    [HttpPost("CriarCliente")]
    public async Task<ActionResult<ResponseModel<ClienteModel>>> CriarClientes(ClienteCriacaoDto clienteCriacaoDto)
    {
        var resposta = await _clienteInterface.CriarCliente(clienteCriacaoDto);

        if (!resposta.Status)
            return BadRequest(resposta);

        return CreatedAtAction(nameof(ListarClientes), resposta);
    }


    [HttpGet("ListarClientes")]
    public async Task<ActionResult<ResponseModel<ClienteModel>>> ListarClientes()
    {
        var resposta = await _clienteInterface.ListarClientes();

        if (!resposta.Status)
            return NotFound(resposta);

        return Ok(resposta);
    }


    [HttpPut("EditarCliente")]
    public async Task<ActionResult<ResponseModel<ClienteModel>>> EditarCliente(ClienteEdicaoDto clienteEdicaoDto)
    {

        var resposta = await _clienteInterface.EditarCliente(clienteEdicaoDto);

        if (!resposta.Status)
            return BadRequest(resposta);

        return Ok(resposta);
    }

    [HttpDelete("DeletarCliente")]
    public async Task<ActionResult<ResponseModel<ClienteModel>>> DeletarCliente(int idCliente)
    {
        var resposta = await _clienteInterface.DeletarCliente(idCliente);

        if (!resposta.Status)
            return NotFound(resposta);
        
        return NoContent();
    }
}