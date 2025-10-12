using AutoMapper;
using Microsoft.EntityFrameworkCore;
using techhelp.api.Data;

namespace techhelp.api.Services;

public class GenericService<TEntity, TReadDto, TCreateDto, TUpdateDto> 
    : IGenericService<TEntity, TReadDto, TCreateDto, TUpdateDto> 
    where TEntity : class
{
    private readonly AppDbContext _appDbContext;
    private readonly DbSet<TEntity> _dbSet;
    private readonly IMapper _mapper;
     
    public GenericService(AppDbContext appDbContext, IMapper mapper) // Construtor
    {
        _appDbContext = appDbContext;
        _dbSet = _appDbContext.Set<TEntity>();
        _mapper = mapper;
    }

    public virtual async Task<IEnumerable<TReadDto>> ListarTodosAsync()
    {
        var lista = await _dbSet.ToListAsync();

        return _mapper.Map<IEnumerable<TReadDto>>(lista);
    }

    public virtual async Task<TReadDto> BuscarPorIdAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);

        return _mapper.Map<TReadDto>(entity);
    }

    public virtual async Task<TReadDto> CriarAsync(TCreateDto dto)
    {
        var entity = _mapper.Map<TEntity>(dto);
        _dbSet.Add(entity);
        await _appDbContext.SaveChangesAsync();

        return _mapper.Map<TReadDto>(entity);
    }

    public virtual async Task<TReadDto> AtualizarAsync(int id, TUpdateDto dto)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null) return default;

        _mapper.Map(dto, entity);
        _appDbContext.Entry(entity).State = EntityState.Modified;
        await _appDbContext.SaveChangesAsync();

        return _mapper.Map<TReadDto>(entity);
    }

    public virtual async Task<bool> DeletarAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null) return false;

        _dbSet.Remove(entity);
        await _appDbContext.SaveChangesAsync();

        return true;
    }
}
