namespace SQLEntity.Models;

public partial class Lavanderia
{
    public int IdLavanderia { get; set; }

    public string? DescricaoServico { get; set; }

    public decimal? ValorServico { get; set; }

    public int? FkContaIdConta { get; set; }

    public virtual Conta? FkContaIdContaNavigation { get; set; }
}
