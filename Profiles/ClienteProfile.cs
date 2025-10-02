using AutoMapper;

public class ClienteProfile : Profile
{
    public ClienteProfile()
    {
        CreateMap<ClienteCriacaoDto, ClienteModel>();
    }
}