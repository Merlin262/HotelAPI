namespace SQLEntity.Models;

public partial class Endereco
{
    public string? Pais { get; set; }

    public string? Estado { get; set; }

    public string? Cidade { get; set; }

    public string? Rua { get; set; }

    public int? Numero { get; set; }

    public int IdEndereco { get; set; }

    public string? Complemento { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<Filial> Filiais { get; set; } = new List<Filial>();
}
