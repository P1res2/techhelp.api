namespace techhelp.api.DTOs;

public class ContratoReadDto
{
    public int Id_contrato { get; set; }
    public int Id_cliente { get; set; }
    public string Tipo_cobranca { get; set; }
    public DateTime Data_inicio { get; set; }
    public DateTime Data_fim { get; set; }
    public decimal Valor { get; set; }
    public string Descricao { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }
}

public class ContratoCreateDto
{
    public int Id_cliente { get; set; }
    public string Tipo_cobranca { get; set; }
    public DateTime Data_inicio { get; set; }
    public DateTime Data_fim { get; set; }
    public decimal Valor { get; set; }
    public string Descricao { get; set; }
    public DateTime Created_at;
}

public class ContratoUpdateDto
{
    public string Tipo_cobranca { get; set; }
    public DateTime? Data_inicio { get; set; }
    public DateTime? Data_fim { get; set; }
    public decimal Valor { get; set; }
    public string Descricao { get; set; }
}
