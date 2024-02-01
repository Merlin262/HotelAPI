namespace SQLEntity.Models;

public class Pedido
{
    public int IdPedido { get; set; }

    public DateOnly? DataPedido { get; set; }

    public int? FkClientesIdCliente { get; set; }

    public virtual Cliente? FkClientesIdClienteNavigation { get; set; }

    public virtual ICollection<ItensPedido> ItensPedidos { get; set; } = new List<ItensPedido>();
}
