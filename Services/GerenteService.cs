using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class GerenteService
{
    private readonly IMapper _mapper;
    private readonly UserManager<GerenteModel> _userManager;
    private readonly SignInManager<GerenteModel> _signInManager;
    private readonly TokenService _tokenService;

    private readonly IHttpContextAccessor _httpContextAccessor;

    private readonly AppDbContext _context;

    public GerenteService(TokenService tokenService, SignInManager<GerenteModel> signInManager, UserManager<GerenteModel> userManager, IMapper mapper, AppDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _tokenService = tokenService;
        _signInManager = signInManager;
        _userManager = userManager;
        _mapper = mapper;
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }


    private string GetGerenteId()
    {
        return _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
    }

    public async Task CadastroGerente(CadastroGerenteDto dto)
    {
        GerenteModel gerente = _mapper.Map<GerenteModel>(dto);
        IdentityResult resultado = await _userManager.CreateAsync(gerente, dto.Senha);
        if (!resultado.Succeeded)
        {
            throw new ApplicationException("Falha ao cadastrar gerente!");
        }

    }
    public async Task<string> LoginGerente(LoginGerenteDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user == null)
        {
            throw new ApplicationException("Gerente não encontrado!");
        }

        var resultado = await _signInManager.CheckPasswordSignInAsync(user, dto.Senha, false);

        if (!resultado.Succeeded)
        {
            throw new ApplicationException("Gerente não autenticado!");
        }

        var token = _tokenService.GenerateToken(user);
        return token;
    }

    public async Task<GerenteDashboardDto> ObterDadosGerente()
    {
        var gerenteId = GetGerenteId();
        
        if (gerenteId == null)
            throw new Exception("Token inválido ou expirado");



        var gerente = await _userManager.FindByIdAsync(gerenteId);
        if (gerente == null)
            throw new ApplicationException("Gerente não encontrado");

        var totalClientes = await _context.Clientes
            .CountAsync(c => c.GerenteId == gerenteId);

        return new GerenteDashboardDto
        {
            Nome = gerente.Nome,
            Email = gerente.Email,
            Empresa = gerente.Empresa,
            TotalClientes = totalClientes
        };
    }
}