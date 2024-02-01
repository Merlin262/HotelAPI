namespace SQLEntity.DTOs
{
    public class LavanderiaDTO
    {
        public int IdLavanderia { get; set; }
        public string DescricaoServico { get; set; }
        public decimal? ValorServico { get; set; }
        public int? FkContaIdConta { get; set; }
    }

}
