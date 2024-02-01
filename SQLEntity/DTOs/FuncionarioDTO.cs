namespace SQLEntity.DTOs
{
    public class FuncionarioDTO
    {
        public int IdFuncionario { get; set; }
        public string NomeFuncionario { get; set; }
        public int? FkFiliaisIdFilial { get; set; }
        public int? FkTipoFuncionarioIdTipoFuncionario { get; set; }
    }
}
