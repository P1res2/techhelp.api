using AutoMapper;
using techhelp.api.Data;
using techhelp.api.DTOs;
using techhelp.api.Models;

namespace techhelp.api.Services;

public class ContratoService : GenericService<Contrato, ContratoReadDto, ContratoCreateDto, ContratoUpdateDto>
{
    public ContratoService(AppDbContext appDbContext, IMapper mapper) : base(appDbContext, mapper) { }
}