using Microsoft.EntityFrameworkCore;
using techhelp.Models;

namespace techhelp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }
    
    public DbSet<Cliente> clientes { get; set; }
}
