using Microsoft.AspNetCore.Mvc;
using SQLEntity.DTOs;

namespace SQLEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPagamentoesController : ControllerBase
    {
        private readonly HotelMaiorContext _context;

        public TipoPagamentoesController(HotelMaiorContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<TipoPagamentoDTO> GetTipoPagamentos()
        {
            using (var _context = new HotelMaiorContext())
            {
                var tiposPagamento = _context.TipoPagamentos
                    .Select(tp => new TipoPagamentoDTO
                    {
                        IdTipoPagamento = tp.IdTipoPagamento,
                        DescricaoTipoPag = tp.DescricaoTipoPag
                    })
                    .ToList();

                return tiposPagamento;
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetTipoPagamentoById(int id)
        {
            using (var _context = new HotelMaiorContext())
            {
                var tipoPagamento = _context.TipoPagamentos
                    .Where(tp => tp.IdTipoPagamento == id)
                    .Select(tp => new TipoPagamentoDTO
                    {
                        IdTipoPagamento = tp.IdTipoPagamento,
                        DescricaoTipoPag = tp.DescricaoTipoPag
                    })
                    .FirstOrDefault();

                if (tipoPagamento == null)
                {
                    return NotFound(); 
                }

                return Ok(tipoPagamento);
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutTipoPagamento(int id, [FromBody] TipoPagamentoDTO tipoPagamentoDTO)
        {
            using (var _context = new HotelMaiorContext())
            {
                var tipoPagamento = _context.TipoPagamentos.Find(id);

                if (tipoPagamento == null)
                {
                    return NotFound(); 
                }

                tipoPagamento.DescricaoTipoPag = tipoPagamentoDTO.DescricaoTipoPag;

                _context.SaveChanges();

                return Ok(); 
            }
        }

        [HttpPost]
        public void PostTipoPagamento([FromBody] TipoPagamentoDTO tipoPagamentoDTO)
        {
            using (var _context = new HotelMaiorContext())
            {
                var tipoPagamento = new TipoPagamento
                {
                    IdTipoPagamento = tipoPagamentoDTO.IdTipoPagamento,
                    DescricaoTipoPag = tipoPagamentoDTO.DescricaoTipoPag
                };

                _context.TipoPagamentos.Add(tipoPagamento);
                _context.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTipoPagamento(int id)
        {
            using (var _context = new HotelMaiorContext())
            {
                var tipoPagamento = _context.TipoPagamentos.Find(id);

                if (tipoPagamento == null)
                {
                    return NotFound(); 
                }

                _context.TipoPagamentos.Remove(tipoPagamento);
                _context.SaveChanges();

                return NoContent(); 
            }
        }

        
    }
}
