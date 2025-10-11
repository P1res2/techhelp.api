using AutoMapper;
using techhelp.api.Data;
using techhelp.api.DTOs;
using techhelp.api.Models;

namespace techhelp.api.Services;

public class ClienteService : GenericService<Cliente, ClienteReadDto, ClienteCreateDto, ClienteUpdateDto>
{
    public ClienteService(AppDbContext appDbContext, IMapper mapper) : base(appDbContext, mapper) { }
}
