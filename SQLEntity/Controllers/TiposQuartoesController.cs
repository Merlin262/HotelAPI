using Microsoft.AspNetCore.Mvc;
using SQLEntity.DTOs;

namespace SQLEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposQuartoesController : ControllerBase
    {
        private readonly HotelMaiorContext _context;

        public TiposQuartoesController(HotelMaiorContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public IEnumerable<TiposQuartoDTO> GetTiposQuarto()
        {
            using (var _context = new HotelMaiorContext())
            {
                var tiposQuarto = _context.TiposQuartos
                    .Select(tq => new TiposQuartoDTO
                    {
                        IdQuarto = tq.IdQuarto,
                        DescricaoQuarto = tq.DescricaoQuarto,
                        ValorQuarto = tq.ValorQuarto
                    })
                    .ToList();

                return tiposQuarto;
            }
        }

       
        [HttpGet("{id}")]
        public IActionResult GetTiposQuartoById(int id)
        {
            using (var _context = new HotelMaiorContext())
            {
                var tipoQuarto = _context.TiposQuartos
                    .Where(tq => tq.IdQuarto == id)
                    .Select(tq => new TiposQuartoDTO
                    {
                        IdQuarto = tq.IdQuarto,
                        DescricaoQuarto = tq.DescricaoQuarto,
                        ValorQuarto = tq.ValorQuarto
                    })
                    .FirstOrDefault();

                if (tipoQuarto == null)
                {
                    return NotFound(); 
                }

                return Ok(tipoQuarto);
            }
        }


        
        [HttpPut("{id}")]
        public IActionResult PutTiposQuarto(int id, [FromBody] TiposQuartoDTO tipoQuartoDTO)
        {
            using (var _context = new HotelMaiorContext())
            {
                var tipoQuarto = _context.TiposQuartos.Find(id);

                if (tipoQuarto == null)
                {
                    return NotFound(); 
                }

                tipoQuarto.DescricaoQuarto = tipoQuartoDTO.DescricaoQuarto;
                tipoQuarto.ValorQuarto = tipoQuartoDTO.ValorQuarto;

                _context.SaveChanges();

                return Ok(); 
            }
        }

        
        [HttpPost]
        public void PostTiposQuarto([FromBody] TiposQuartoDTO tipoQuartoDTO)
        {
            using (var _context = new HotelMaiorContext())
            {
                var tipoQuarto = new TiposQuarto
                {
                    IdQuarto = tipoQuartoDTO.IdQuarto,
                    DescricaoQuarto = tipoQuartoDTO.DescricaoQuarto,
                    ValorQuarto = tipoQuartoDTO.ValorQuarto
                };

                _context.TiposQuartos.Add(tipoQuarto);
                _context.SaveChanges();
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteTiposQuarto(int id)
        {
            using (var _context = new HotelMaiorContext())
            {
                var tipoQuarto = _context.TiposQuartos.Find(id);

                if (tipoQuarto == null)
                {
                    return NotFound(); 
                }

                _context.TiposQuartos.Remove(tipoQuarto);
                _context.SaveChanges();

                return NoContent(); 
            }
        }

    }
}
