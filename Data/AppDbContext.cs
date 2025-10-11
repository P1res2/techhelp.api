using Microsoft.EntityFrameworkCore;
using techhelp.api.Models;

namespace techhelp.api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }
    
    public DbSet<Cliente> clientes { get; set; }
    public DbSet<Contrato> contratos { get; set; }
}
