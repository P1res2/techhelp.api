namespace techhelp.api.Models;
public class TecnicoEspecialidade : IModel
{
    public int Id_tecnico { get; set; }
    public Tecnico Tecnico { get; set; } = null!;
    public int Id_especialidade { get; set; }
    public Especialidade Especialidade { get; set; } = null!;
    public DateTime Created_at { get; set; }
}
