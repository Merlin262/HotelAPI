namespace SQLEntity.DTOs
{
    public class PedidoDTO
    {
        public int IdPedido { get; set; }
        public DateOnly? DataPedido { get; set; }
        public int? FkClientesIdCliente { get; set; }
    }

}
