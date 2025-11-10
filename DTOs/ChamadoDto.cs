namespace techhelp.api.DTOs;

public class ChamadoReadDto
{
    public int Id_chamado { get; set; }
    public int Id_cliente { get; set; }
    public int? Id_tecnico { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public string Prioridade { get; set;}
    public string Status { get; set; }
    public string Tipo_atendimento { get; set; }
    public string Categoria { get; set; }
    public DateTime Data_abertura { get; set; }
    public DateTime Data_fechamento { get; set; }
    public TimeSpan Tempo_resolucao { get; set; }
    public TimeSpan Sla_maximo { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }
}

public class ChamadoCreateDto
{
    public int Id_cliente { get; set; }
    public int? Id_tecnico;
    public string Titulo {get; set;}
    public string Descricao { get; set; }
    public string Prioridade { get; set; }
    public string Status;
    public string Tipo_atendimento { get; set; }
    public string Categoria { get; set; }
    public DateTime Data_abertura;
    public DateTime Created_at;
}

public class ChamadoUpdateDto
{
    public int? Id_tecnico { get; set; }
    public string Prioridade {get; set;}
    public string Status { get; set;}
    public string Tipo_atendimento { get; set; }
    public string Categoria { get; set; }
    public DateTime? Data_fechamento { get; set; }
    public TimeSpan? Tempo_resolucao { get; set; }
    public TimeSpan? Sla_maximo { get; set; }
    public DateTime Updated_at;
}