using Microsoft.AspNetCore.Mvc;
using techhelp.api.DTOs;
using techhelp.api.Models;
using techhelp.api.Services;

namespace techhelp.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContratosController : GenericController<Contrato, ContratoReadDto, ContratoCreateDto, ContratoUpdateDto>
{
    public ContratosController(IGenericService<Contrato, ContratoReadDto, ContratoCreateDto, ContratoUpdateDto> service) : base(service) { }
}
