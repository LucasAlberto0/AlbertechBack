using Microsoft.EntityFrameworkCore;

public class ClienteService : IClienteInterface
{
    private readonly AppDbContext _context;

    public ClienteService(AppDbContext context)
    {
        _context = context;
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

    public Task<ResponseModel<List<ClienteModel>>> DeletarCliente(ClienteCriacaoDto clienteCriacaoDto)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel<List<ClienteModel>>> EditarCliente(ClienteCriacaoDto clienteCriacaoDto)
    {
        throw new NotImplementedException();
    }
}

