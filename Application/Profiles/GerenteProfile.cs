using AutoMapper;

public class GerenteProfile : Profile
{
    public GerenteProfile()
    {
        CreateMap<CadastroGerenteDto, GerenteModel>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
    }
}
