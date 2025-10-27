public interface IClienteRepository
{
    Task<List<ClienteModel>> GetAllByGerenteIdAsync(string gerenteId);

    Task<ClienteModel?> GetByIdAsync(int id, string gerenteId);

    Task AddAsync(ClienteModel cliente);

    void Update(ClienteModel cliente);

    void Delete(ClienteModel cliente);
    
    Task SaveChangesAsync();
}
