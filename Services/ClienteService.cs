using AutoMapper;
using Microsoft.EntityFrameworkCore;
using techhelp.api.Data;
using techhelp.api.DTOs;
using techhelp.api.Models;

namespace techhelp.api.Services;

public class ClienteService : GenericService<Cliente, ClienteReadDto, ClienteCreateDto, ClienteUpdateDto>
{
    private readonly AppDbContext _appDbContext;
    private readonly DbSet<Cliente> _dbSet;
    private readonly IMapper _mapper;

    public ClienteService(AppDbContext appDbContext, IMapper mapper) : base(appDbContext, mapper)
    {
        _appDbContext = appDbContext;
        _dbSet = _appDbContext.Set<Cliente>();
        _mapper = mapper;
    }

    public async Task<ClienteReadDto> BuscarPorCpfCnpjAsync(string cpf_cnpj)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(c => c.Cpf_cnpj == cpf_cnpj);

        return _mapper.Map<ClienteReadDto>(entity);
    }

    public override async Task<ClienteReadDto> CriarAsync(ClienteCreateDto dto)
    {
        dto.Created_at = DateTime.Now;
        return await base.CriarAsync(dto);
    }

    public override async Task<ClienteReadDto> AtualizarAsync(int id, ClienteUpdateDto dto)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null) return null;

        entity.Updated_at = DateTime.Now;

        if (!string.IsNullOrWhiteSpace(dto.Nome_razao)) entity.Nome_razao = dto.Nome_razao;

        if (!string.IsNullOrWhiteSpace(dto.Tipo)) entity.Tipo = dto.Tipo;

        if (!string.IsNullOrWhiteSpace(dto.Email)) entity.Email = dto.Email;

        if (!string.IsNullOrWhiteSpace(dto.Telefone)) entity.Telefone = dto.Telefone;

        await _appDbContext.SaveChangesAsync();
        return _mapper.Map<ClienteReadDto>(entity);
    }
}
