using System.ComponentModel.DataAnnotations;

namespace techhelp.Models;

public class Cliente
{
    [Key]
    public int Id_cliente { get; set; }
    public string Nome_razao { get; set; }
    public string Cpf_cnpj { get; set; }
    public string Tipo { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }
}
