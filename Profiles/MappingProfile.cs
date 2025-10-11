using AutoMapper;
using techhelp.api.Models;
using techhelp.api.DTOs;

namespace techhelp.api.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Cliente Mapping
        CreateMap<Cliente, ClienteReadDto>().ReverseMap();
        CreateMap<ClienteCreateDto, Cliente>();
        CreateMap<ClienteUpdateDto, Cliente>();

        // Contrato Mapping
        CreateMap<Contrato, ContratoReadDto>().ReverseMap();
        CreateMap<ContratoCreateDto, Contrato>();
        CreateMap<ContratoUpdateDto, Contrato>();
    }
}
