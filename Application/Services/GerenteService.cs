using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class GerenteService : IGerenteInterface
{
    private readonly IMapper _mapper;
    private readonly UserManager<GerenteModel> _userManager;
    private readonly SignInManager<GerenteModel> _signInManager;
    private readonly TokenService _tokenService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly AppDbContext _context;

    public GerenteService(
        TokenService tokenService,
        SignInManager<GerenteModel> signInManager,
        UserManager<GerenteModel> userManager,
        IMapper mapper,
        AppDbContext context,
        IHttpContextAccessor httpContextAccessor)
    {
        _tokenService = tokenService;
        _signInManager = signInManager;
        _userManager = userManager;
        _mapper = mapper;
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    private string GetGerenteId()
        => _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

    public async Task<ResponseModel<GerenteModel>> CadastroGerente(CadastroGerenteDto dto)
    {
        var resposta = new ResponseModel<GerenteModel>();
        try
        {
            var gerente = _mapper.Map<GerenteModel>(dto);
            var resultado = await _userManager.CreateAsync(gerente, dto.Senha);

            if (!resultado.Succeeded)
                throw new Exception("Falha ao cadastrar gerente!");

            resposta.Dados = gerente;
            resposta.Mensagem = "Gerente cadastrado com sucesso!";
            resposta.Status = true;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
        }

        return resposta;
    }

    public async Task<ResponseModel<string>> LoginGerente(LoginGerenteDto dto)
    {
        var resposta = new ResponseModel<string>();
        try
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
                throw new Exception("Gerente não encontrado!");

            var resultado = await _signInManager.CheckPasswordSignInAsync(user, dto.Senha, false);
            if (!resultado.Succeeded)
                throw new Exception("Gerente não autenticado!");

            var token = _tokenService.GenerateToken(user);
            resposta.Token = token;
            resposta.Mensagem = "Login realizado com sucesso!";
            resposta.Status = true;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
        }

        return resposta;
    }

    public async Task<ResponseModel<GerenteDashboardDto>> ObterDashboard()
    {
        var resposta = new ResponseModel<GerenteDashboardDto>();
        try
        {
            var gerenteId = GetGerenteId();
            if (gerenteId == null)
                throw new Exception("Token inválido ou expirado");

            var gerente = await _userManager.FindByIdAsync(gerenteId);
            if (gerente == null)
                throw new Exception("Gerente não encontrado");

            var totalClientes = await _context.Clientes
                .CountAsync(c => c.GerenteId == gerenteId);

            var dashboard = new GerenteDashboardDto
            {
                Nome = gerente.Nome,
                Email = gerente.Email,
                Empresa = gerente.Empresa,
                TotalClientes = totalClientes
            };

            resposta.Dados = dashboard;
            resposta.Mensagem = "Dados do gerente obtidos com sucesso!";
            resposta.Status = true;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
        }

        return resposta;
    }
}
