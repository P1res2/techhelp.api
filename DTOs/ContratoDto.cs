namespace techhelp.api.DTOs;

public class ContratoReadDto
{
    public int Id { get; set; }
    public string TipoCobranca { get; set; }
    public decimal Valor { get; set; }
    public string Descricao { get; set; }
}

public class ContratoCreateDto
{
    public int ClienteId { get; set; }
    public string TipoCobranca { get; set; }
    public decimal Valor { get; set; }
    public string Descricao { get; set; }
}

public class ContratoUpdateDto
{
    public string TipoCobranca { get; set; }
    public decimal Valor { get; set; }
    public string Descricao { get; set; }
}
