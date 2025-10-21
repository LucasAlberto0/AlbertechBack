using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

public class ClienteService : IClienteInterface
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly AppDbContext _context;

    public ClienteService(AppDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }
    
    private string GetGerenteId()
    {
        return _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
    }

    public async Task<ResponseModel<List<ClienteModel>>> ListarClientes()
    {
        ResponseModel<List<ClienteModel>> resposta = new ResponseModel<List<ClienteModel>>();
        try
        {
            var gerenteId = GetGerenteId();
            if (gerenteId == null)
                throw new Exception("Gerente não autenticado");

            var clientes = await _context.Clientes
                .Where(c => c.GerenteId == gerenteId)
                .ToListAsync();

            resposta.Dados = clientes;
            resposta.Mensagem = "Clientes do gerente listados!";
            resposta.Status = true;
            return resposta;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
    }

    public async Task<ResponseModel<List<ClienteModel>>> CriarCliente(ClienteCriacaoDto clienteCriacaoDto)
    {
        ResponseModel<List<ClienteModel>> resposta = new ResponseModel<List<ClienteModel>>();
        try
        {
            var gerenteId = GetGerenteId();
            if (gerenteId == null)
                throw new Exception("Gerente não autenticado");

            var cliente = new ClienteModel()
            {
                Nome = clienteCriacaoDto.Nome,
                Email = clienteCriacaoDto.Email,
                DataNascimento = clienteCriacaoDto.DataNascimento,
                Cpf = clienteCriacaoDto.Cpf,
                Endereco = clienteCriacaoDto.Endereco,
                GerenteId = gerenteId 
            };

            _context.Add(cliente);
            await _context.SaveChangesAsync();

            resposta.Dados = await _context.Clientes
                .Where(c => c.GerenteId == gerenteId)
                .ToListAsync();

            resposta.Mensagem = "Cliente criado com sucesso!";
            resposta.Status = true;
            return resposta;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
    }

    public async Task<ResponseModel<List<ClienteModel>>> EditarCliente(ClienteEdicaoDto clienteEdicaoDto)
    {
        ResponseModel<List<ClienteModel>> resposta = new ResponseModel<List<ClienteModel>>();
        try
        {
            var gerenteId = GetGerenteId();
            if (gerenteId == null)
                throw new Exception("Gerente não autenticado");

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(c => c.Id == clienteEdicaoDto.Id && c.GerenteId == gerenteId);

            if (cliente == null)
            {
                resposta.Mensagem = "Nenhum cliente localizado";
                resposta.Status = false;
                return resposta;
            }

            cliente.Nome = clienteEdicaoDto.Nome;
            cliente.Email = clienteEdicaoDto.Email;
            cliente.Cpf = clienteEdicaoDto.Cpf;
            cliente.Endereco = clienteEdicaoDto.Endereco;

            _context.Update(cliente);
            await _context.SaveChangesAsync();

            resposta.Dados = await _context.Clientes
                .Where(c => c.GerenteId == gerenteId)
                .ToListAsync();

            resposta.Mensagem = "Cliente editado com sucesso!";
            resposta.Status = true;
            return resposta;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
    }

    public async Task<ResponseModel<List<ClienteModel>>> DeletarCliente(int idCliente)
    {
        ResponseModel<List<ClienteModel>> resposta = new ResponseModel<List<ClienteModel>>();
        try
        {
            var gerenteId = GetGerenteId();
            if (gerenteId == null)
                throw new Exception("Gerente não autenticado");

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(c => c.Id == idCliente && c.GerenteId == gerenteId);

            if (cliente == null)
            {
                resposta.Mensagem = "Nenhum cliente encontrado!";
                resposta.Status = false;
                return resposta;
            }

            _context.Remove(cliente);
            await _context.SaveChangesAsync();

            resposta.Dados = await _context.Clientes
                .Where(c => c.GerenteId == gerenteId)
                .ToListAsync();

            resposta.Mensagem = "Cliente removido com sucesso!";
            resposta.Status = true;
            return resposta;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
    }
}
