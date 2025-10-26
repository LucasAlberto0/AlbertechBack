using Microsoft.EntityFrameworkCore;

public class ClienteRepository : IClienteRepository
{
    private readonly AppDbContext _context;

    public ClienteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ClienteModel>> GetAllByGerenteIdAsync(string gerenteId)
        => await _context.Clientes.Where(c => c.GerenteId == gerenteId).ToListAsync();

    public async Task<ClienteModel?> GetByIdAsync(int id, string gerenteId)
        => await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id && c.GerenteId == gerenteId);

    public async Task AddAsync(ClienteModel cliente)
        => await _context.Clientes.AddAsync(cliente);

    public void Update(ClienteModel cliente)
        => _context.Clientes.Update(cliente);

    public void Delete(ClienteModel cliente)
        => _context.Clientes.Remove(cliente);

    public async Task SaveChangesAsync()
        => await _context.SaveChangesAsync();
}
