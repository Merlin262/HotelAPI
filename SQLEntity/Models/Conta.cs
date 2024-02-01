namespace SQLEntity.Models;

public partial class Conta
{
    public int IdConta { get; set; }

    public decimal? Valor { get; set; }

    public decimal? ValorItens { get; set; }

    public int? FkReservasIdReserva { get; set; }

    public virtual Reserva? FkReservasIdReservaNavigation { get; set; }

    public virtual ICollection<Lavanderia> Lavanderia { get; set; } = new List<Lavanderia>();

    public virtual ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();
}
