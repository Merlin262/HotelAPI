using Microsoft.AspNetCore.Mvc;
using SQLEntity.DTOs;

namespace SQLEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItensController : ControllerBase
    {
        private readonly HotelMaiorContext _context;

        public ItensController(HotelMaiorContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<ItenDTO> GetItens()
        {
            using (var _context = new HotelMaiorContext())
            {
                var itens = _context.Itens
                    .Select(i => new ItenDTO
                    {
                        IdItens = i.IdItens,
                        DescricaoItem = i.DescricaoItem,
                        ValorItem = i.ValorItem,
                        Entrega = i.Entrega,
                        FkFiliaisIdFilial = i.FkFiliaisIdFilial
                    })
                    .ToList();

                return itens;
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetItenById(int id)
        {
            using (var _context = new HotelMaiorContext())
            {
                var iten = _context.Itens
                    .Where(i => i.IdItens == id)
                    .Select(i => new ItenDTO
                    {
                        IdItens = i.IdItens,
                        DescricaoItem = i.DescricaoItem,
                        ValorItem = i.ValorItem,
                        Entrega = i.Entrega,
                        FkFiliaisIdFilial = i.FkFiliaisIdFilial
                    })
                    .FirstOrDefault();

                if (iten == null)
                {
                    return NotFound(); 
                }

                return Ok(iten);
            }
        }


        [HttpPut("{id}")]
        public IActionResult PutIten(int id, [FromBody] ItenDTO itenDTO)
        {
            using (var _context = new HotelMaiorContext())
            {
                var iten = _context.Itens.Find(id);

                if (iten == null)
                {
                    return NotFound(); 
                }

                iten.DescricaoItem = itenDTO.DescricaoItem;
                iten.ValorItem = itenDTO.ValorItem;
                iten.Entrega = itenDTO.Entrega;
                iten.FkFiliaisIdFilial = itenDTO.FkFiliaisIdFilial;

                _context.SaveChanges();

                return Ok(); 
            }
        }


        [HttpPost]
        public void PostIten([FromBody] ItenDTO itenDTO)
        {
            using (var _context = new HotelMaiorContext())
            {
                var iten = new Iten
                {
                    IdItens = itenDTO.IdItens,
                    DescricaoItem = itenDTO.DescricaoItem,
                    ValorItem = itenDTO.ValorItem,
                    Entrega = itenDTO.Entrega,
                    FkFiliaisIdFilial = itenDTO.FkFiliaisIdFilial
                };

                _context.Itens.Add(iten);
                _context.SaveChanges();
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteIten(int id)
        {
            using (var _context = new HotelMaiorContext())
            {
                var iten = _context.Itens.Find(id);

                if (iten == null)
                {
                    return NotFound(); 
                }

                _context.Itens.Remove(iten);
                _context.SaveChanges();

                return NoContent(); 
            }
        }

    }
}
