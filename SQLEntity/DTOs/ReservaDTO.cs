namespace SQLEntity.DTOs
{
    public class ReservaDTO
    {
        public int IdReserva { get; set; }
        public DateOnly? CheckIn { get; set; }
        public DateOnly? CheckOut { get; set; }
        public bool? Cancelado { get; set; }
        public decimal? Valor { get; set; }
        public int? NumPessoas { get; set; }
        public int? FkClientesIdCliente { get; set; }
        public int? FkFuncionariosIdFuncionario { get; set; }
    }

}
