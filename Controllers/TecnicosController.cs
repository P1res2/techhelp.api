using Microsoft.AspNetCore.Mvc;
using techhelp.api.DTOs;
using techhelp.api.Models;
using techhelp.api.Services;

namespace techhelp.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TecnicosController : GenericController<Tecnico, TecnicoReadDto, TecnicoCreateDto, TecnicoUpdateDto>
{
    private readonly TecnicoService _TecnicoService;

    public TecnicosController(TecnicoService service) : base(service)
    {
        _TecnicoService = service;
    }
}
