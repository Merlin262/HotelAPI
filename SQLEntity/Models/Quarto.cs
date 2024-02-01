namespace SQLEntity.Models;

public partial class Quarto
{
    public int NumeroQuarto { get; set; }

    public int? CapacidadeMaxima { get; set; }

    public bool? CapacidadeOpcional { get; set; }

    public bool? Adaptavel { get; set; }

    public int? FkFiliaisIdFilial { get; set; }

    public int? FkTiposQuartoIdQuarto { get; set; }

    public int? FkReservasIdReserva { get; set; }

    public virtual Filial? FkFiliaisIdFilialNavigation { get; set; }

    public virtual Reserva? FkReservasIdReservaNavigation { get; set; }

    public virtual TiposQuarto? FkTiposQuartoIdQuartoNavigation { get; set; }
}
