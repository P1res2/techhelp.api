using System.ComponentModel.DataAnnotations;

namespace techhelp.api.Models;

public class Tecnico : IModel
{
    [Key]
    public int Id_tecnico { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Senha { get; set; }
    public bool Ativo { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }

    public ICollection<TecnicoEspecialidade> TecnicoEspecialidades { get; set; } = new List<TecnicoEspecialidade>();
}
