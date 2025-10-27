public interface IClienteInterface
{
    Task<ResponseModel<List<ClienteModel>>> ListarClientes();

    Task<ResponseModel<List<ClienteModel>>> CriarCliente(ClienteCriacaoDto clienteCriacaoDto);

    Task<ResponseModel<List<ClienteModel>>> EditarCliente(ClienteEdicaoDto clienteEdicaoDto);
    
    Task<ResponseModel<List<ClienteModel>>> DeletarCliente(int idCliente);
}

