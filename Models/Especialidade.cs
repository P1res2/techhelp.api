using System.ComponentModel.DataAnnotations;

namespace techhelp.api.Models;

public class Especialidade : IModel
{
    [Key]
    public int Id_especialidade { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public DateTime Created_at { get; set; }

     public ICollection<TecnicoEspecialidade> TecnicoEspecialidades { get; set; } = new List<TecnicoEspecialidade>();
}
