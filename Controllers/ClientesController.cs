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

        return Ok(listaClientes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetClienteById(int id)
    {
        var cliente = await _appDbContext.clientes.FindAsync(id);

        if (cliente == null)
            return NotFound(new { message = "Cliente não encontrado" });

        return Ok(cliente);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCliente(int id, Cliente cliente)
    {
        // if (id != cliente.Id_cliente)
        //     return BadRequest(new { message = "ID da URL não bate com o ID do cliente" });

        var clienteExistente = await _appDbContext.clientes.FindAsync(id);

        if (clienteExistente == null)
            return NotFound(new { message = "Cliente não encontrado" });

        // Atualiza os campos
        if (!string.IsNullOrEmpty(cliente.Nome_razao))
            clienteExistente.Nome_razao = cliente.Nome_razao;

        if (!string.IsNullOrEmpty(cliente.Email))
            clienteExistente.Email = cliente.Email;

        if (!string.IsNullOrEmpty(cliente.Telefone))
            clienteExistente.Telefone = cliente.Telefone;

        clienteExistente.Updated_at = DateTime.UtcNow;


        _appDbContext.Entry(clienteExistente).State = EntityState.Modified;
        await _appDbContext.SaveChangesAsync();

        return Ok(clienteExistente);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCliente(int id)
    {
        var cliente = await _appDbContext.clientes.FindAsync(id);

        if (cliente == null)
            return NotFound(new { message = "Cliente não encontrado" });

        _appDbContext.clientes.Remove(cliente);
        await _appDbContext.SaveChangesAsync();

        return NoContent();
    }

}
