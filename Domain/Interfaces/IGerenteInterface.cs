public interface IGerenteInterface
{
    Task<ResponseModel<GerenteModel>> CadastroGerente(CadastroGerenteDto dto);

    Task<ResponseModel<string>> LoginGerente(LoginGerenteDto dto);

    Task<ResponseModel<GerenteModel>> EditarGerente(GerenteEdicaoDto dto);
    
    Task<ResponseModel<GerenteDashboardDto>> ObterDadosDoGerente();
}
