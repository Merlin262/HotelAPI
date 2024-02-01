namespace SQLEntity.Models;

public partial class Pagamento
{
    public int CodigoNotaFiscal { get; set; }

    public DateTime? DataNotaFiscal { get; set; }

    public decimal? ValorTotalNotaFiscal { get; set; }

    public int? CodigoTipoPagamento { get; set; }

    public int? FkContaIdConta { get; set; }

    public int? FkTipoPagamentoIdTipoPagamento { get; set; }

    public virtual Conta? FkContaIdContaNavigation { get; set; }

    public virtual TipoPagamento? FkTipoPagamentoIdTipoPagamentoNavigation { get; set; }
}
