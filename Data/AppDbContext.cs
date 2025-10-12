using Microsoft.EntityFrameworkCore;
using techhelp.api.Models;

namespace techhelp.api.Data;

public class AppDbContext : DbContext
{
    public DbSet<Cliente> clientes { get; set; }
    public DbSet<Contrato> contratos { get; set; }
    public DbSet<Tecnico> tecnicos { get; set; }
    public DbSet<Especialidade> especialidades { get; set; }
    public DbSet<TecnicoEspecialidade> tecnico_especialidades { get; set; }

    public AppDbContext(DbContextOptions options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Relacionamento Tecnico-Especialista
        modelBuilder.Entity<TecnicoEspecialidade>()
            .HasKey(te => new { te.Id_tecnico, te.Id_especialidade });

        modelBuilder.Entity<TecnicoEspecialidade>()
            .HasOne(te => te.Tecnico)
            .WithMany(t => t.TecnicoEspecialidades)
            .HasForeignKey(te => te.Id_tecnico);

        modelBuilder.Entity<TecnicoEspecialidade>()
            .HasOne(te => te.Especialidade)
            .WithMany(e => e.TecnicoEspecialidades)
            .HasForeignKey(te => te.Id_especialidade);
    }
}
