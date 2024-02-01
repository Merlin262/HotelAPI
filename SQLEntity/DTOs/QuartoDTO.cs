namespace SQLEntity.DTOs
{
    public class QuartoDTO
    {
        public int NumeroQuarto { get; set; }
        public int? CapacidadeMaxima { get; set; }
        public bool? CapacidadeOpcional { get; set; }
        public bool? Adaptavel { get; set; }
        public int? FkFiliaisIdFilial { get; set; }
        public int? FkTiposQuartoIdQuarto { get; set; }
        //public int? FkReservasIdReserva { get; set; }
    }

}
