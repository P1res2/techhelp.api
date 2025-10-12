using AutoMapper;
using Microsoft.EntityFrameworkCore;
using techhelp.api.Data;
using techhelp.api.DTOs;
using techhelp.api.Models;

namespace techhelp.api.Services;

public class TecnicoService : GenericService<Tecnico, TecnicoReadDto, TecnicoCreateDto, TecnicoUpdateDto>
{
    private readonly AppDbContext _appDbContext;
    private readonly DbSet<Tecnico> _dbSet;
    private readonly IMapper _mapper;

    public TecnicoService(AppDbContext appDbContext, IMapper mapper) : base(appDbContext, mapper)
    {
        _appDbContext = appDbContext;
        _dbSet = _appDbContext.Set<Tecnico>();
        _mapper = mapper;
    }

    public override async Task<IEnumerable<TecnicoReadDto>> ListarTodosAsync()
    {
        var lista = await _dbSet
            .Include(t => t.TecnicoEspecialidades)
            .ThenInclude(te => te.Especialidade)
            .ToListAsync();

        return _mapper.Map<IEnumerable<TecnicoReadDto>>(lista);
    }

    public override async Task<TecnicoReadDto> BuscarPorIdAsync(int id)
    {
        var entity = await _dbSet
            .Include(t => t.TecnicoEspecialidades)
            .ThenInclude(te => te.Especialidade)
            .FirstOrDefaultAsync(t => t.Id_tecnico == id);

        return _mapper.Map<TecnicoReadDto>(entity);
    }

    public override async Task<TecnicoReadDto> CriarAsync(TecnicoCreateDto dto)
    {
        dto.Ativo = true;
        dto.Created_at = DateTime.Now;
        var tecnico = await base.CriarAsync(dto);
        foreach (var Id_esp in dto.Ids_especialidades)
        {
            _appDbContext.Add(new TecnicoEspecialidade
            {
                Id_especialidade = Id_esp,
                Id_tecnico = tecnico.Id_tecnico,
                Created_at = DateTime.Now
            });
        }

        await _appDbContext.SaveChangesAsync();
        return tecnico;
    }

    public override async Task<TecnicoReadDto> AtualizarAsync(int id, TecnicoUpdateDto dto)
    {
        var entity = await _dbSet
            .Include(t => t.TecnicoEspecialidades)
            .FirstOrDefaultAsync(t => t.Id_tecnico == id);

        if (entity == null) return null;

        // Atualiza campos básicos
        entity.Updated_at = DateTime.Now;

        if (!string.IsNullOrWhiteSpace(dto.Nome)) entity.Nome = dto.Nome;

        if (!string.IsNullOrWhiteSpace(dto.Email)) entity.Email = dto.Email;

        if (!string.IsNullOrWhiteSpace(dto.Telefone)) entity.Telefone = dto.Telefone;

        if (dto.Ativo != entity.Ativo) entity.Ativo = dto.Ativo;

        if (dto.Ids_especialidades != null && dto.Ids_especialidades.Any())
        {
            // Remove os relacionamentos antigos
            _appDbContext.Set<TecnicoEspecialidade>().RemoveRange(entity.TecnicoEspecialidades);

            // Adiciona os novos
            foreach (var idEsp in dto.Ids_especialidades)
            {
                entity.TecnicoEspecialidades.Add(new TecnicoEspecialidade
                {
                    Id_tecnico = entity.Id_tecnico,
                    Id_especialidade = idEsp,
                    Created_at = DateTime.Now
                });
            }
        }

        await _appDbContext.SaveChangesAsync();

        // Recarrega o técnico com as especialidades pra retornar completo
        var atualizado = await _dbSet
            .Include(t => t.TecnicoEspecialidades)
            .ThenInclude(te => te.Especialidade)
            .FirstOrDefaultAsync(t => t.Id_tecnico == id);

        return _mapper.Map<TecnicoReadDto>(atualizado);
    }
}
