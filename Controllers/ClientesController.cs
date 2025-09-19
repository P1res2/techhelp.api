using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using techhelp.Models;

namespace techhelp.Data;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly AppDbContext _appDbContext;

    public ClientesController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    [HttpPost]
    public async Task<IActionResult> PostCliente(Cliente cliente)
    {
        _appDbContext.clientes.Add(cliente);
        await _appDbContext.SaveChangesAsync();

        return Ok(cliente);
    }

    [HttpGet]
    public async Task<IActionResult> GetClientes()
    {
        IEnumerable<Cliente> listaClientes = await _appDbContext.clientes.ToListAsync();
        // string json = JsonSerializer.Serialize(listaClientes, new JsonSerializerOptions
        // {
        //     WriteIndented = true
        // });

        return Ok(listaClientes);
    }
}
