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
        var resultado = await _signInManager.PasswordSignInAsync(dto.Email, dto.Password, false, false);

        if (!resultado.Succeeded)
        {
            throw new ApplicationException("Usuário não autenticado!");
        }

        var email = _signInManager
        .UserManager
        .Users
        .FirstOrDefault(email => email.NormalizedEmail == dto.Email.ToUpper());

        var token = _tokenService.GenerateToken(email);
    }
}