namespace SQLEntity.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? NomeCliente { get; set; }

    public string? Nacionalidade { get; set; }

    public string? EmailCliente { get; set; }

    public string? TelefoneCliente { get; set; }

    public int? FkEnderecoIdEndereco { get; set; }

    public virtual Endereco? FkEnderecoIdEnderecoNavigation { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
