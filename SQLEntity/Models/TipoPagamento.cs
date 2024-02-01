namespace SQLEntity.Models;

public partial class TipoPagamento
{
    public int IdTipoPagamento { get; set; }

    public string? DescricaoTipoPag { get; set; }

    public virtual ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();
}
