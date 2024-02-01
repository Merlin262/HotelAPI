namespace SQLEntity.DTOs
{
    public class ItenDTO
    {
        public int IdItens { get; set; }
        public string DescricaoItem { get; set; }
        public decimal? ValorItem { get; set; }
        public bool? Entrega { get; set; }
        public int? FkFiliaisIdFilial { get; set; }
    }


}
