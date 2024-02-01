namespace SQLEntity.NovaPasta
{
    public class EnderecoDTO
    {
        public int IdEndereco { get; set; }
        public string Pais { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Rua { get; set; }
        public int? Numero { get; set; }
    }

}
