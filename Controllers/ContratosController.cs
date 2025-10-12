using Microsoft.AspNetCore.Mvc;
using techhelp.api.DTOs;
using techhelp.api.Models;
using techhelp.api.Services;

namespace techhelp.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContratosController : GenericController<Contrato, ContratoReadDto, ContratoCreateDto, ContratoUpdateDto>
{
    private readonly ContratoService _ContratoService;

    public ContratosController(ContratoService service) : base(service)
    {
        _ContratoService = service;
    }

    [HttpGet("Cliente/{id}")]
    public async Task<ActionResult<ClienteReadDto>> GetContratosByClienteID(int id)
    {
        var item = await _ContratoService.BuscarContratosPorIdClientejAsync(id);
        return item == null ? NotFound(new { message = "Nenhum encontrado" }) : Ok(item);
    }
}
