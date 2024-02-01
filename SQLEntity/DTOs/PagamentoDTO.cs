namespace SQLEntity.DTOs
{
    public class PagamentoDTO
    {
        public int CodigoNotaFiscal { get; set; }
        public DateTime? DataNotaFiscal { get; set; }
        public decimal? ValorTotalNotaFiscal { get; set; }
        public int? CodigoTipoPagamento { get; set; }
        public int? FkContaIdConta { get; set; }
        public int? FkTipoPagamentoIdTipoPagamento { get; set; }
    }

}
