namespace SQLEntity.Models;

public partial class Reserva
{
    public int IdReserva { get; set; }

    public DateOnly? CheckIn { get; set; }

    public DateOnly? CheckOut { get; set; }

    public bool? Cancelado { get; set; }

    public decimal? Valor { get; set; }

    public int? NumPessoas { get; set; }

    public int? FkClientesIdCliente { get; set; }

    public int? FkFuncionariosIdFuncionario { get; set; }

    public virtual ICollection<Conta> Conta { get; set; } = new List<Conta>();

    public virtual Cliente? FkClientesIdClienteNavigation { get; set; }

    public virtual Funcionario? FkFuncionariosIdFuncionarioNavigation { get; set; }

    public virtual ICollection<Quarto> Quartos { get; set; } = new List<Quarto>();
}
