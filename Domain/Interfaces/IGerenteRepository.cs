public interface IGerenteRepository
{
    Task<GerenteModel> GetByIdAsync(string id);

    Task<GerenteModel> GetByEmailAsync(string email);

    Task<int> CountClientesAsync(string gerenteId);
    
    Task AddAsync(GerenteModel gerente);
}
