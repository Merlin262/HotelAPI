namespace SQLEntity.DTOs
{
    public class ContaDTO
    {
        public int IdConta { get; set; }
        public decimal? Valor { get; set; }
        public decimal? ValorItens { get; set; }
        public int? FkReservasIdReserva { get; set; }
    }

}
