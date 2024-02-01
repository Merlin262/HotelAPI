namespace SQLEntity.Models;

public class ItensPedido
{
    public int IdItemPedido { get; set; }

    public string? DescricaoItem { get; set; }

    public int? Quantidade { get; set; }

    public decimal? ValorItem { get; set; }

    public int? FkPedidosIdPedido { get; set; }

    public virtual Pedido? FkPedidosIdPedidoNavigation { get; set; }
}
