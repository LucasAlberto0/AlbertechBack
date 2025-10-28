using System.Linq.Expressions;

public interface IGerenteRepository
{
    Task<GerenteModel> GetByIdAsync(string id);

    Task<GerenteModel> GetByEmailAsync(string email);

    Task<int> CountClientesAsync(string gerenteId);

    Task<int> CountClientesByStatusAsync(string gerenteId, string status);

    Task AddAsync(GerenteModel gerente);

    Task UpdateAsync(GerenteModel gerente);
}
