using Microsoft.AspNetCore.Mvc;
using SQLEntity.DTOs;

namespace SQLEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LavanderiasController : ControllerBase
    {
        private readonly HotelMaiorContext _context;

        public LavanderiasController(HotelMaiorContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<LavanderiaDTO> GetLavanderia()
        {
            using (var _context = new HotelMaiorContext())
            {
                var lavanderias = _context.Lavanderia
                    .Select(l => new LavanderiaDTO
                    {
                        IdLavanderia = l.IdLavanderia,
                        DescricaoServico = l.DescricaoServico,
                        ValorServico = l.ValorServico,
                        FkContaIdConta = l.FkContaIdConta
                    })
                    .ToList();

                return lavanderias;
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetLavanderiaById(int id)
        {
            using (var _context = new HotelMaiorContext())
            {
                var lavanderia = _context.Lavanderia
                    .Where(l => l.IdLavanderia == id)
                    .Select(l => new LavanderiaDTO
                    {
                        IdLavanderia = l.IdLavanderia,
                        DescricaoServico = l.DescricaoServico,
                        ValorServico = l.ValorServico,
                        FkContaIdConta = l.FkContaIdConta
                    })
                    .FirstOrDefault();

                if (lavanderia == null)
                {
                    return NotFound(); 
                }

                return Ok(lavanderia);
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutLavanderia(int id, [FromBody] LavanderiaDTO lavanderiaDTO)
        {
            using (var _context = new HotelMaiorContext())
            {
                var lavanderia = _context.Lavanderia.Find(id);

                if (lavanderia == null)
                {
                    return NotFound(); 
                }

                lavanderia.DescricaoServico = lavanderiaDTO.DescricaoServico;
                lavanderia.ValorServico = lavanderiaDTO.ValorServico;
                lavanderia.FkContaIdConta = lavanderiaDTO.FkContaIdConta;

                _context.SaveChanges();

                return Ok(); 
            }
        }

        [HttpPost]
        public void PostLavanderia([FromBody] LavanderiaDTO lavanderiaDTO)
        {
            using (var _context = new HotelMaiorContext())
            {
                var lavanderia = new Lavanderia
                {
                    IdLavanderia = lavanderiaDTO.IdLavanderia,
                    DescricaoServico = lavanderiaDTO.DescricaoServico,
                    ValorServico = lavanderiaDTO.ValorServico,
                    FkContaIdConta = lavanderiaDTO.FkContaIdConta
                };

                _context.Lavanderia.Add(lavanderia);
                _context.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLavanderia(int id)
        {
            using (var _context = new HotelMaiorContext())
            {
                var lavanderia = _context.Lavanderia.Find(id);

                if (lavanderia == null)
                {
                    return NotFound(); 
                }

                _context.Lavanderia.Remove(lavanderia);
                _context.SaveChanges();

                return NoContent(); 
            }
        }

    }
}
