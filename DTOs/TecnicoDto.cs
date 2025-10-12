namespace techhelp.api.DTOs;

public class TecnicoReadDto
{
    public int Id_tecnico { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public bool Ativo { get; set; }
    public List<EspecialidadeReadDto> Especialidades { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }
}

public class TecnicoCreateDto
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Senha { get; set; }
    public List<int> Ids_especialidades { get; set; } = new();
    public bool Ativo;
    public DateTime Created_at;
}

public class TecnicoUpdateDto
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public List<int> Ids_especialidades { get; set; } = new();
    public bool Ativo { get; set; }
}
