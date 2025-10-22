using Microsoft.AspNetCore.Mvc;
using techhelp.api.DTOs;
using techhelp.api.Models;
using techhelp.api.Services;

namespace techhelp.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChamadosController : GenericController<Chamado, ChamadoReadDto, ChamadoCreateDto, ChamadoUpdateDto>
{
    private readonly ChamadoService _ChamadoService;

    public ChamadosController(ChamadoService service) : base(service)
    {
        _ChamadoService = service;
    }

    [HttpGet("Cliente/{id}")]
    public async Task<ActionResult<ClienteReadDto>> GetChamadosByClienteID(int id)
    {
        var item = await _ChamadoService.BuscarChamadosPorIdClientejAsync(id);
        return item == null ? NotFound(new { message = "Nenhum encontrado" }) : Ok(item);
    }

    [HttpGet("Tecnico/{id}")]
    public async Task<ActionResult<ClienteReadDto>> GetChamadosByTecnicoID(int id)
    {
        var item = await _ChamadoService.BuscarChamadosPorIdTecnicojAsync(id);
        return item == null ? NotFound(new { message = "Nenhum encontrado" }) : Ok(item);
    }

    [HttpGet("Abertos/")]
    public async Task<ActionResult<ClienteReadDto>> GetChamadosAbertos()
    {
        var item = await _ChamadoService.BuscarChamadosAbertosAsync();
        return item == null ? NotFound(new { message = "Nenhum encontrado" }) : Ok(item);
    }

    [HttpGet("Fechados/")]
    public async Task<ActionResult<ClienteReadDto>> GetChamadosFechados()
    {
        var item = await _ChamadoService.BuscarChamadosFechadosAsync();
        return item == null ? NotFound(new { message = "Nenhum encontrado" }) : Ok(item);
    }
}
