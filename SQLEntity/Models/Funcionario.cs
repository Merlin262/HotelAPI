namespace SQLEntity.Models;

public partial class Funcionario
{
    public int IdFuncionario { get; set; }

    public string? NomeFuncionario { get; set; }

    public int? FkFiliaisIdFilial { get; set; }

    public int? FkTipoFuncionarioIdTipoFuncionario { get; set; }

    public virtual Filial? FkFiliaisIdFilialNavigation { get; set; }

    public virtual TipoFuncionario? FkTipoFuncionarioIdTipoFuncionarioNavigation { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
