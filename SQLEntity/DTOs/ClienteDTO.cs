namespace SQLEntity.DTOs
{
    public class ClienteDTO
    {
        public int IdCliente { get; set; }
        public string NomeCliente { get; set; }
        public string Nacionalidade { get; set; }
        public string EmailCliente { get; set; }
        public string TelefoneCliente { get; set; }
        public int? FkEnderecoIdEndereco { get; set; }
    }
}
