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

    [HttpPost]
    public async Task<ActionResult<ResponseModel<ClienteModel>>> CriarClientes(ClienteCriacaoDto clienteCriacaoDto)
    {
        var clientes = await _clienteInterface.CriarCliente(clienteCriacaoDto);
        return Ok(clientes);
    }
}