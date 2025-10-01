public interface IClienteInterface
{
    Task<ResponseModel<List<ClienteModel>>> CriarCliente(ClienteCriacaoDto clienteCriacaoDto);
    Task<ResponseModel<List<ClienteModel>>> EditarCliente(ClienteCriacaoDto clienteCriacaoDto);
    Task<ResponseModel<List<ClienteModel>>> DeletarCliente(ClienteCriacaoDto clienteCriacaoDto);
}

public class ResponseModel<T>
{
    public T? Dados { get; set; }
    public string Mensagem { get; set; } = string.Empty;
    public bool Status { get; set; }
}