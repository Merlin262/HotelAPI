using Microsoft.AspNetCore.Mvc;
using SQLEntity.DTOs;

namespace SQLEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuartosController : ControllerBase
    {
        private readonly HotelMaiorContext _context;

        public QuartosController(HotelMaiorContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<QuartoDTO> GetQuartos()
        {
            using (var _context = new HotelMaiorContext())
            {
                var quartos = _context.Quartos
                    .Select(q => new QuartoDTO
                    {
                        NumeroQuarto = q.NumeroQuarto,
                        CapacidadeMaxima = q.CapacidadeMaxima,
                        CapacidadeOpcional = q.CapacidadeOpcional,
                        Adaptavel = q.Adaptavel,
                        FkFiliaisIdFilial = q.FkFiliaisIdFilial,
                        FkTiposQuartoIdQuarto = q.FkTiposQuartoIdQuarto,
                    })
                    .ToList();

                return quartos;
            }
        }

        [HttpGet("{numeroQuarto}")]
        public IActionResult GetQuartoByNumero(int numeroQuarto)
        {
            using (var _context = new HotelMaiorContext())
            {
                var quarto = _context.Quartos
                    .Where(q => q.NumeroQuarto == numeroQuarto)
                    .Select(q => new QuartoDTO
                    {
                        NumeroQuarto = q.NumeroQuarto,
                        CapacidadeMaxima = q.CapacidadeMaxima,
                        CapacidadeOpcional = q.CapacidadeOpcional,
                        Adaptavel = q.Adaptavel,
                        FkFiliaisIdFilial = q.FkFiliaisIdFilial,
                        FkTiposQuartoIdQuarto = q.FkTiposQuartoIdQuarto,
                    })
                    .FirstOrDefault();

                if (quarto == null)
                {
                    return NotFound(); 
                }

                return Ok(quarto);
            }
        }

        [HttpPut("{numeroQuarto}")]
        public IActionResult PutQuarto(int numeroQuarto, [FromBody] QuartoDTO quartoDTO)
        {
            using (var _context = new HotelMaiorContext())
            {
                var quarto = _context.Quartos.Find(numeroQuarto);

                if (quarto == null)
                {
                    return NotFound(); 
                }

                quarto.CapacidadeMaxima = quartoDTO.CapacidadeMaxima;
                quarto.CapacidadeOpcional = quartoDTO.CapacidadeOpcional;
                quarto.Adaptavel = quartoDTO.Adaptavel;
                quarto.FkFiliaisIdFilial = quartoDTO.FkFiliaisIdFilial;
                quarto.FkTiposQuartoIdQuarto = quartoDTO.FkTiposQuartoIdQuarto;

                _context.SaveChanges();

                return Ok(); 
            }
        }


        [HttpPost]
        public void PostQuarto([FromBody] QuartoDTO quartoDTO)
        {
            using (var _context = new HotelMaiorContext())
            {
                var quarto = new Quarto
                {
                    NumeroQuarto = quartoDTO.NumeroQuarto,
                    CapacidadeMaxima = quartoDTO.CapacidadeMaxima,
                    CapacidadeOpcional = quartoDTO.CapacidadeOpcional,
                    Adaptavel = quartoDTO.Adaptavel,
                    FkFiliaisIdFilial = quartoDTO.FkFiliaisIdFilial,
                    FkTiposQuartoIdQuarto = quartoDTO.FkTiposQuartoIdQuarto,
                    
                };

                _context.Quartos.Add(quarto);
                _context.SaveChanges();
            }
        }

        [HttpDelete("{numeroQuarto}")]
        public IActionResult DeleteQuarto(int numeroQuarto)
        {
            using (var _context = new HotelMaiorContext())
            {
                var quarto = _context.Quartos.Find(numeroQuarto);

                if (quarto == null)
                {
                    return NotFound(); 
                }

                _context.Quartos.Remove(quarto);
                _context.SaveChanges();

                return NoContent(); 
            }
        }

    }
}
