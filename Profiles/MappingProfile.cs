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

        // Tecnico Mapping
        CreateMap<Tecnico, TecnicoReadDto>().ReverseMap();
        CreateMap<TecnicoCreateDto, Tecnico>();
        CreateMap<TecnicoUpdateDto, Tecnico>();

        // Especialidades Mapping
        CreateMap<Especialidade, EspecialidadeReadDto>().ReverseMap();
        CreateMap<EspecialidadeCreateDto, Especialidade>();
        CreateMap<EspecialidadeUpdateDto, Especialidade>();

        CreateMap<Tecnico, TecnicoReadDto>().ForMember(dest => dest.Especialidades, opt => opt.MapFrom(src => src.TecnicoEspecialidades.Select(te => te.Especialidade)));
        CreateMap<Especialidade, EspecialidadeReadDto>();
    }
}
