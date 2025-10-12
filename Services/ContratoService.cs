using AutoMapper;
using Microsoft.EntityFrameworkCore;
using techhelp.api.Data;
using techhelp.api.DTOs;
using techhelp.api.Models;

namespace techhelp.api.Services;

public class ContratoService : GenericService<Contrato, ContratoReadDto, ContratoCreateDto, ContratoUpdateDto>
{
    private readonly AppDbContext _appDbContext;
    private readonly DbSet<Contrato> _dbSet;
    private readonly IMapper _mapper;

    public ContratoService(AppDbContext appDbContext, IMapper mapper) : base(appDbContext, mapper)
    {
        _appDbContext = appDbContext;
        _dbSet = _appDbContext.Set<Contrato>();
        _mapper = mapper;
    }

    public async Task<IEnumerable<ContratoReadDto>> BuscarContratosPorIdClientejAsync(int id)
    {
        var lista = await _dbSet.Where(a => a.Id_cliente == id).ToListAsync();

        return _mapper.Map<IEnumerable<ContratoReadDto>>(lista);
    }

    public override async Task<ContratoReadDto> CriarAsync(ContratoCreateDto dto)
    {
        dto.Created_at = DateTime.Now;
        return await base.CriarAsync(dto);
    }

    public override async Task<ContratoReadDto> AtualizarAsync(int id, ContratoUpdateDto dto)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null) return null;

        entity.Updated_at = DateTime.Now;

        if (!string.IsNullOrWhiteSpace(dto.Tipo_cobranca)) entity.Tipo_cobranca = dto.Tipo_cobranca;

        if (dto.Data_inicio.HasValue) entity.Data_inicio = dto.Data_inicio;

        if (dto.Data_fim.HasValue) entity.Data_fim = dto.Data_fim;

        if (decimal.IsPositive(dto.Valor) && dto.Valor != 0) entity.Valor = dto.Valor;

        if (!string.IsNullOrWhiteSpace(dto.Descricao)) entity.Descricao = dto.Descricao;

        await _appDbContext.SaveChangesAsync();
        return _mapper.Map<ContratoReadDto>(entity);
    }
}
