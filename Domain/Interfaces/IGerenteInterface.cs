public interface IGerenteInterface
{
    Task<ResponseModel<GerenteModel>> CadastroGerente(CadastroGerenteDto dto);
    Task<ResponseModel<string>> LoginGerente(LoginGerenteDto dto);
    Task<ResponseModel<GerenteDashboardDto>> ObterDashboard();
}
