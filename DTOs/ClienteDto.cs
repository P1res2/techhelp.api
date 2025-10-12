namespace techhelp.api.DTOs;

public class ClienteReadDto
{
    public int Id_cliente { get; set; }
    public string Nome_razao { get; set; }
    public string Cpf_cnpj { get; set; }
    public string Tipo { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }
}

public class ClienteCreateDto
{
    public string Nome_razao { get; set; }
    public string Cpf_cnpj { get; set; }
    public string Tipo { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public DateTime Created_at;
}

public class ClienteUpdateDto
{
    public string Nome_razao { get; set; }
    public string Tipo { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
}
