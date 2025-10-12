using Microsoft.AspNetCore.Mvc;
using techhelp.api.DTOs;
using techhelp.api.Models;
using techhelp.api.Services;

namespace techhelp.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : GenericController<Cliente, ClienteReadDto, ClienteCreateDto, ClienteUpdateDto>
{
    private readonly ClienteService _ClienteService;

    public ClientesController(ClienteService service) : base(service)
    {
        _ClienteService = service;
    }

   [HttpGet("CpfCnpj/{cpf_cnpj}")]
    public async Task<ActionResult<ClienteReadDto>> GetByCpfCnpj(string cpf_cnpj)
    {
        var item = await _ClienteService.BuscarPorCpfCnpjAsync(cpf_cnpj);
        return item == null ? NotFound(new { message = "Nenhum encontrado" }) : Ok(item);
    }
}
