using AutoMapper;
using Microsoft.EntityFrameworkCore;
using techhelp.api.Data;
using techhelp.api.DTOs;
using techhelp.api.Models;

namespace techhelp.api.Services;

public class ChamadoService : GenericService<Chamado, ChamadoReadDto, ChamadoCreateDto, ChamadoUpdateDto>
{
    private readonly AppDbContext _appDbContext;
    private readonly DbSet<Chamado> _dbSet;
    private readonly IMapper _mapper;

    public ChamadoService(AppDbContext appDbContext, IMapper mapper) : base(appDbContext, mapper)
    {
        _appDbContext = appDbContext;
        _dbSet = _appDbContext.Set<Chamado>();
        _mapper = mapper;
    }

    public async Task<IEnumerable<ChamadoReadDto>> BuscarChamadosPorIdClientejAsync(int id)
    {
        var lista = await _dbSet.Where(a => a.Id_cliente == id).ToListAsync();

        return _mapper.Map<IEnumerable<ChamadoReadDto>>(lista);
    }

    public async Task<IEnumerable<ChamadoReadDto>> BuscarChamadosPorIdTecnicojAsync(int id)
    {
        var lista = await _dbSet.Where(a => a.Id_tecnico == id).ToListAsync();

        return _mapper.Map<IEnumerable<ChamadoReadDto>>(lista);
    }

    public async Task<IEnumerable<ChamadoReadDto>> BuscarChamadosAbertosAsync()
    {
        var lista = await _dbSet.Where(a =>
            a.Status == "Aberto" ||
            a.Status == "Em Andamento" ||
            a.Status == "Aguardando Cliente"
        ).ToListAsync();

        return _mapper.Map<IEnumerable<ChamadoReadDto>>(lista);
    }

    public async Task<IEnumerable<ChamadoReadDto>> BuscarChamadosFechadosAsync()
    {
        var lista = await _dbSet.Where(a => a.Status == "Fechado" || a.Status == "Resolvido").ToListAsync();

        return _mapper.Map<IEnumerable<ChamadoReadDto>>(lista);
    }

    public override async Task<ChamadoReadDto> CriarAsync(ChamadoCreateDto dto)
    {
        dto.Created_at = DateTime.Now;
        dto.Data_abertura = DateTime.Now;
        dto.Prioridade = "Média";
        dto.Status = "Aberto";
        return await base.CriarAsync(dto);
    }

    public override async Task<ChamadoReadDto> AtualizarAsync(int id, ChamadoUpdateDto dto)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null) return null;

        entity.Updated_at = DateTime.Now;

        if (dto.Id_tecnico != null) entity.Id_tecnico = dto.Id_tecnico;

        if (!string.IsNullOrWhiteSpace(dto.Prioridade)) entity.Prioridade = dto.Prioridade;

        if (!string.IsNullOrWhiteSpace(dto.Status)) entity.Status = dto.Status;

        if (!string.IsNullOrWhiteSpace(dto.Tipo_atendimento)) entity.Tipo_atendimento = dto.Tipo_atendimento;

        if (!string.IsNullOrWhiteSpace(dto.Categoria)) entity.Categoria = dto.Categoria;

        if (dto.Data_fechamento != null) entity.Data_fechamento = dto.Data_fechamento;

        if (dto.Tempo_resolucao != null) entity.Tempo_resolucao = dto.Tempo_resolucao;

        if (dto.Sla_maximo != null) entity.Sla_maximo = dto.Sla_maximo;

        await _appDbContext.SaveChangesAsync();
        return _mapper.Map<ChamadoReadDto>(entity);
    }
}
