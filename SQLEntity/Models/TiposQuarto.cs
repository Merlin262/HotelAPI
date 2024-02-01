namespace SQLEntity.Models;

public partial class TiposQuarto
{
    public int IdQuarto { get; set; }

    public string? DescricaoQuarto { get; set; }

    public decimal? ValorQuarto { get; set; }

    public virtual ICollection<Quarto> Quartos { get; set; } = new List<Quarto>();
}
