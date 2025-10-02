using Microsoft.AspNetCore.Mvc;


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
            var clientes = await _clienteInterface.CriarCliente(clienteCriacaoDto);
            return Ok(clientes);
        }

    [HttpGet("ListarClientes")]
    public async Task<ActionResult<ResponseModel<ClienteModel>>> ListarClientes()
    {
        var clientes = await _clienteInterface.ListarClientes();
        return Ok(clientes);
    }

    
    [HttpPut("EditarCliente")]
    public async Task<ActionResult<ResponseModel<ClienteModel>>> EditarCliente(ClienteEdicaoDto clienteEdicaoDto){
        var clientes = await _clienteInterface.EditarCliente(clienteEdicaoDto);
        return Ok(clientes);
    }

    [HttpDelete("DeletarCliente")]
    public async Task<ActionResult<ResponseModel<ClienteModel>>> DeletarCliente(int idCliente)
    {
        var clientes = await _clienteInterface.DeletarCliente(idCliente);
        return Ok(clientes);
    }
}