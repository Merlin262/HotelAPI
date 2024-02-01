namespace SQLEntity.Models;

public partial class TipoFuncionario
{
    public int IdTipoFuncionario { get; set; }

    public string? Descricao { get; set; }

    public virtual ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
}
