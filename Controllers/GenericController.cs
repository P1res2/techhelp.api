using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using techhelp.api.Services;

namespace techhelp.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenericController<TEntity, TReadDto, TCreateDto, TUpdateDto> : ControllerBase where TEntity : class
{
    private readonly IGenericService<TEntity, TReadDto, TCreateDto, TUpdateDto> _service;

    public GenericController(IGenericService<TEntity, TReadDto, TCreateDto, TUpdateDto> service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TReadDto>>> GetAll() => Ok(await _service.ListarTodosAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<TReadDto>> GetById(int id)
    {
        var item = await _service.BuscarPorIdAsync(id);
        return item == null ? NotFound(new { message = "Nenhum encontrado" }) : Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<TReadDto>> Post(TCreateDto entity)
    {
        var novo = await _service.CriarAsync(entity);
        return Ok(novo);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TReadDto>> Put(int id, TUpdateDto entity)
    {
        await _service.AtualizarAsync(id, entity);
        return Ok(new {message = "Atualizado com sucesso!"});
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<TReadDto>> Delete(int id)
    {
        var ok = await _service.DeletarAsync(id);
        return ok ? Ok(new {message = "Deletado com sucesso!"}) : NotFound();
    }
}
