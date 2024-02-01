namespace SQLEntity.DTOs
{
    public class ItensPedidoDTO
    {
        public int IdItemPedido { get; set; }
        public string DescricaoItem { get; set; }
        public int? Quantidade { get; set; }
        public decimal? ValorItem { get; set; }
        public int? FkPedidosIdPedido { get; set; }
    }
}
