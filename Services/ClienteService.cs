using Microsoft.EntityFrameworkCore;

public class ClienteService : IClienteInterface
{
    private readonly AppDbContext _context;

    public ClienteService(AppDbContext context)
    {
        _context = context;
    }


    public async Task<ResponseModel<List<ClienteModel>>> ListarClientes()
    {
        ResponseModel<List<ClienteModel>> resposta = new ResponseModel<List<ClienteModel>>();
        try
        {
            var clientes = await _context.Clientes.ToListAsync();

            resposta.Dados = clientes;
            resposta.Mensagem = "Todos os clientes foram Listados!";

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
            var cliente = new ClienteModel()
            {
                Nome = clienteCriacaoDto.Nome,
                Email = clienteCriacaoDto.Email,
                DataNascimento = clienteCriacaoDto.DataNascimento,
                Cpf = clienteCriacaoDto.Cpf

            };

            _context.Add(cliente);
            await _context.SaveChangesAsync();

            resposta.Dados = await _context.Clientes.ToListAsync();
            resposta.Mensagem = "Cliente criado com sucesso!";

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
            var cliente = await _context.Clientes.FirstOrDefaultAsync(clienteBanco => clienteBanco.Id == clienteEdicaoDto.Id);

            if (cliente == null)
            {
                resposta.Mensagem = "Nenhum clinte localizado";
                return resposta;
            }

            cliente.Nome = clienteEdicaoDto.Nome;
            cliente.Email = clienteEdicaoDto.Email;
            cliente.Cpf = clienteEdicaoDto.Cpf;
            cliente.Endereco = clienteEdicaoDto.Endereco;

            _context.Update(cliente);
            await _context.SaveChangesAsync();

            resposta.Dados = await _context.Clientes.ToListAsync();
            resposta.Mensagem = "Cliente editado com sucesso!";

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
            var cliente = await _context.Clientes.FirstOrDefaultAsync(clienteBanco => clienteBanco.Id == idCliente);

            if (cliente == null)
            {
                resposta.Mensagem = "Nenhum cliente encontrado!";
                return resposta;
            }

            _context.Remove(cliente);
            await _context.SaveChangesAsync();

            resposta.Dados = await _context.Clientes.ToListAsync();
            resposta.Mensagem = "Removida com Sucesso!";

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

