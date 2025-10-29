using Microsoft.EntityFrameworkCore;

public class GerenteRepository : IGerenteRepository
{
    private readonly AppDbContext _context;

    public GerenteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<GerenteModel> GetByIdAsync(string id)
    {
        return await _context.Users.OfType<GerenteModel>().FirstOrDefaultAsync(g => g.Id == id);
    }

    public async Task<GerenteModel> GetByEmailAsync(string email)
    {
        return await _context.Users.OfType<GerenteModel>().FirstOrDefaultAsync(g => g.Email == email);
    }

    public async Task<int> CountClientesAsync(string gerenteId)
    {
        return await _context.Clientes.CountAsync(c => c.GerenteId == gerenteId);
    }

    public async Task<int> CountClientesByStatusAsync(string gerenteId, string status)
    {
        return await _context.Clientes
            .CountAsync(c => c.GerenteId == gerenteId && c.Status.ToLower() == status.ToLower());
    }


    public async Task AddAsync(GerenteModel gerente)
    {
        await _context.Users.AddAsync(gerente);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(GerenteModel gerente)
    {
        _context.Users.Update(gerente);
        await _context.SaveChangesAsync();
    }
}
