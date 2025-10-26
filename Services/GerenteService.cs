using AutoMapper;
using Microsoft.AspNetCore.Identity;

public class GerenteService
{
    private IMapper _mapper;
    private UserManager<GerenteModel> _userManager;
    private SignInManager<GerenteModel> _signInManager;
    private TokenService _tokenService;

    public GerenteService(TokenService tokenService, SignInManager<GerenteModel> signInManager, UserManager<GerenteModel> userManager, IMapper mapper)
    {
        _tokenService = tokenService;
        _signInManager = signInManager;
        _userManager = userManager;
        _mapper = mapper;
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

}