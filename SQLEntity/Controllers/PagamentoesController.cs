using Microsoft.AspNetCore.Mvc;
using SQLEntity.DTOs;

namespace SQLEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoesController : ControllerBase
    {
        private readonly HotelMaiorContext _context;

        public PagamentoesController(HotelMaiorContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<PagamentoDTO> GetPagamentos()
        {
            using (var _context = new HotelMaiorContext())
            {
                var pagamentos = _context.Pagamentos
                    .Select(p => new PagamentoDTO
                    {
                        CodigoNotaFiscal = p.CodigoNotaFiscal,
                        DataNotaFiscal = p.DataNotaFiscal,
                        ValorTotalNotaFiscal = p.ValorTotalNotaFiscal,
                        CodigoTipoPagamento = p.CodigoTipoPagamento,
                        FkContaIdConta = p.FkContaIdConta,
                        FkTipoPagamentoIdTipoPagamento = p.FkTipoPagamentoIdTipoPagamento
                    })
                    .ToList();

                return pagamentos;
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPagamentoById(int id)
        {
            using (var _context = new HotelMaiorContext())
            {
                var pagamento = _context.Pagamentos
                    .Where(p => p.CodigoNotaFiscal == id)
                    .Select(p => new PagamentoDTO
                    {
                        CodigoNotaFiscal = p.CodigoNotaFiscal,
                        DataNotaFiscal = p.DataNotaFiscal,
                        ValorTotalNotaFiscal = p.ValorTotalNotaFiscal,
                        CodigoTipoPagamento = p.CodigoTipoPagamento,
                        FkContaIdConta = p.FkContaIdConta,
                        FkTipoPagamentoIdTipoPagamento = p.FkTipoPagamentoIdTipoPagamento
                    })
                    .FirstOrDefault();

                if (pagamento == null)
                {
                    return NotFound(); 
                }

                return Ok(pagamento);
            }
        }

        // PUT: api/Pagamento/5
        [HttpPut("{id}")]
        public IActionResult PutPagamento(int id, [FromBody] PagamentoDTO pagamentoDTO)
        {
            using (var _context = new HotelMaiorContext())
            {
                var pagamento = _context.Pagamentos.Find(id);

                if (pagamento == null)
                {
                    return NotFound(); 
                }

                pagamento.DataNotaFiscal = pagamentoDTO.DataNotaFiscal;
                pagamento.ValorTotalNotaFiscal = pagamentoDTO.ValorTotalNotaFiscal;
                pagamento.CodigoTipoPagamento = pagamentoDTO.CodigoTipoPagamento;
                pagamento.FkContaIdConta = pagamentoDTO.FkContaIdConta;
                pagamento.FkTipoPagamentoIdTipoPagamento = pagamentoDTO.FkTipoPagamentoIdTipoPagamento;

                _context.SaveChanges();

                return Ok(); 
            }
        }



        [HttpPost]
        public void PostPagamento([FromBody] PagamentoDTO pagamentoDTO)
        {
            using (var _context = new HotelMaiorContext())
            {
                var pagamento = new Pagamento
                {
                    CodigoNotaFiscal = pagamentoDTO.CodigoNotaFiscal,
                    DataNotaFiscal = pagamentoDTO.DataNotaFiscal,
                    ValorTotalNotaFiscal = pagamentoDTO.ValorTotalNotaFiscal,
                    CodigoTipoPagamento = pagamentoDTO.CodigoTipoPagamento,
                    FkContaIdConta = pagamentoDTO.FkContaIdConta,
                    FkTipoPagamentoIdTipoPagamento = pagamentoDTO.FkTipoPagamentoIdTipoPagamento
                };

                _context.Pagamentos.Add(pagamento);
                _context.SaveChanges();
            }
        }



        [HttpDelete("{id}")]
        public IActionResult DeletePagamento(int id)
        {
            using (var _context = new HotelMaiorContext())
            {
                var pagamento = _context.Pagamentos.Find(id);

                if (pagamento == null)
                {
                    return NotFound(); 
                }

                _context.Pagamentos.Remove(pagamento);
                _context.SaveChanges();

                return NoContent(); 
            }
        }

    }
}
