namespace SQLEntity.Models;

public partial class Filial
{
    public string? NomeFilial { get; set; }

    public int? NumeroQuartos { get; set; }

    public int? QtdEstrelas { get; set; }

    public double? CoeficienteFilialPreco { get; set; }

    public int IdFilial { get; set; }

    public int? FkEnderecoIdEndereco { get; set; }

    public virtual Endereco? FkEnderecoIdEnderecoNavigation { get; set; }

    public virtual ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();

    public virtual ICollection<Iten> Itens { get; set; } = new List<Iten>();

    public virtual ICollection<Quarto> Quartos { get; set; } = new List<Quarto>();
}
