using AutoMapper;

public class GerenteProfile : Profile
{
    public GerenteProfile()
    {
        CreateMap<CadastroGerenteDto, GerenteModel>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => DateTime.SpecifyKind(src.DataNascimento, DateTimeKind.Utc)));
    }
}
