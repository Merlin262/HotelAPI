namespace SQLEntity.DTOs
{
    public class FilialDTO
    {
        public string NomeFilial { get; set; }
        public int? NumeroQuartos { get; set; }
        public int? QtdEstrelas { get; set; }
        public double? CoeficienteFilialPreco { get; set; }
        public int IdFilial { get; set; }
        public int? FkEnderecoIdEndereco { get; set; }
    }

}
