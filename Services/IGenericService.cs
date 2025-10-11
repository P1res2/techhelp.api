namespace techhelp.api.Services;

public interface IGenericService<TEntity, TReadDto, TCreateDto, TUpdateDto> where TEntity : class
{
    Task<IEnumerable<TReadDto>> ListarTodosAsync();
    Task<TReadDto> BuscarPorIdAsync(int id);
    Task<TReadDto> CriarAsync(TCreateDto obj);
    Task<TReadDto> AtualizarAsync(int id, TUpdateDto obj);
    Task<bool> DeletarAsync(int id);
}
