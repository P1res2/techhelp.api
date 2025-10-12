using AutoMapper;
using Microsoft.EntityFrameworkCore;
using techhelp.api.Data;
using techhelp.api.DTOs;
using techhelp.api.Models;

namespace techhelp.api.Services;

public class EspecialidadeService : GenericService<Especialidade, EspecialidadeReadDto, EspecialidadeCreateDto, EspecialidadeUpdateDto>
{
    private readonly AppDbContext _appDbContext;
    private readonly DbSet<Especialidade> _dbSet;
    private readonly IMapper _mapper;

    public EspecialidadeService(AppDbContext appDbContext, IMapper mapper) : base(appDbContext, mapper)
    {
        _appDbContext = appDbContext;
        _dbSet = _appDbContext.Set<Especialidade>();
        _mapper = mapper;
    }

    public override Task<EspecialidadeReadDto> CriarAsync(EspecialidadeCreateDto dto)
    {
        dto.Created_at = DateTime.Now;
        return base.CriarAsync(dto);
    }

    public override async Task<EspecialidadeReadDto> AtualizarAsync(int id, EspecialidadeUpdateDto dto)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null) return null;

        if (!string.IsNullOrWhiteSpace(dto.Nome)) entity.Nome = dto.Nome;

        if (!string.IsNullOrWhiteSpace(dto.Descricao)) entity.Descricao = dto.Descricao;

        await _appDbContext.SaveChangesAsync();
        return _mapper.Map<EspecialidadeReadDto>(entity);
    }
}
