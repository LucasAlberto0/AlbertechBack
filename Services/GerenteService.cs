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

    public async Task<string> Login(LoginGerenteDto dto)
{
    var user = await _userManager.FindByEmailAsync(dto.Email);
    if (user == null)
    {
        throw new ApplicationException("Usuário não encontrado!");
    }

    var resultado = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);

    if (!resultado.Succeeded)
    {
        throw new ApplicationException("Usuário não autenticado!");
    }

    var token = _tokenService.GenerateToken(user);
    return token;
}

}