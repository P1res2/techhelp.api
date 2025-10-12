using Microsoft.AspNetCore.Mvc;
using techhelp.api.DTOs;
using techhelp.api.Models;
using techhelp.api.Services;

namespace techhelp.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EspecialidadesController : GenericController<Especialidade, EspecialidadeReadDto, EspecialidadeCreateDto, EspecialidadeUpdateDto>
{
    private readonly EspecialidadeService _EspecialidadeService;

    public EspecialidadesController(EspecialidadeService service) : base(service)
    {
        _EspecialidadeService = service;
    }
}