using System.Security.Claims;
using AutoMapper;

public class ClienteService : IClienteInterface
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IClienteRepository _clienteRepository;

    private readonly IMapper _mapper;

    public ClienteService(IClienteRepository clienteRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper)
    {
        _clienteRepository = clienteRepository;
        _httpContextAccessor = httpContextAccessor;
        _mapper = mapper;
    }

    private string GetGerenteId()
        => _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

    public async Task<ResponseModel<List<ClienteModel>>> ListarClientes()
    {
        var resposta = new ResponseModel<List<ClienteModel>>();
        try
        {
            var gerenteId = GetGerenteId();
            if (gerenteId == null)
                throw new Exception("Gerente não autenticado");

            var clientes = await _clienteRepository.GetAllByGerenteIdAsync(gerenteId);
            resposta.Dados = clientes;
            resposta.Mensagem = "Clientes do gerente listados!";
            resposta.Status = true;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
        }

        return resposta;
    }

    public async Task<ResponseModel<List<ClienteModel>>> CriarCliente(ClienteCriacaoDto dto)
    {
        var resposta = new ResponseModel<List<ClienteModel>>();
        try
        {
            var gerenteId = GetGerenteId();
            if (gerenteId == null)
                throw new Exception("Gerente não autenticado");

            var cliente = _mapper.Map<ClienteModel>(dto);
            cliente.GerenteId = gerenteId;

            await _clienteRepository.AddAsync(cliente);
            await _clienteRepository.SaveChangesAsync();

            resposta.Dados = await _clienteRepository.GetAllByGerenteIdAsync(gerenteId);
            resposta.Mensagem = "Cliente criado com sucesso!";
            resposta.Status = true;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
        }

        return resposta;
    }

    public async Task<ResponseModel<List<ClienteModel>>> EditarCliente(ClienteEdicaoDto dto)
    {
        var resposta = new ResponseModel<List<ClienteModel>>();
        try
        {
            var gerenteId = GetGerenteId();
            if (gerenteId == null)
                throw new Exception("Gerente não autenticado");

            var cliente = await _clienteRepository.GetByIdAsync(dto.Id, gerenteId);
            if (cliente == null)
                throw new Exception("Cliente não encontrado");

            _mapper.Map(dto, cliente);

            _clienteRepository.Update(cliente);
            await _clienteRepository.SaveChangesAsync();

            resposta.Dados = await _clienteRepository.GetAllByGerenteIdAsync(gerenteId);
            resposta.Mensagem = "Cliente editado com sucesso!";
            resposta.Status = true;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
        }

        return resposta;
    }

    public async Task<ResponseModel<List<ClienteModel>>> DeletarCliente(int idCliente)
    {
        var resposta = new ResponseModel<List<ClienteModel>>();
        try
        {
            var gerenteId = GetGerenteId();
            if (gerenteId == null)
                throw new Exception("Gerente não autenticado");

            var cliente = await _clienteRepository.GetByIdAsync(idCliente, gerenteId);
            if (cliente == null)
                throw new Exception("Cliente não encontrado");

            _clienteRepository.Delete(cliente);
            await _clienteRepository.SaveChangesAsync();

            resposta.Dados = await _clienteRepository.GetAllByGerenteIdAsync(gerenteId);
            resposta.Mensagem = "Cliente removido com sucesso!";
            resposta.Status = true;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
        }

        return resposta;
    }
}
