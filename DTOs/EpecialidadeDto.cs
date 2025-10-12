namespace techhelp.api.DTOs;

public class EspecialidadeReadDto
{
    public int Id_especialidade { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
}

public class EspecialidadeCreateDto
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public DateTime Created_at;
}

public class EspecialidadeUpdateDto
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
}