using Microsoft.AspNetCore.Mvc;
using SQLEntity.DTOs;

namespace SQLEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasController : ControllerBase
    {
        private readonly HotelMaiorContext _context;

        public ContasController(HotelMaiorContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<ContaDTO> GetContas()
        {
            using (var _context = new HotelMaiorContext())
            {
                var contas = _context.Conta
                    .Select(c => new ContaDTO
                    {
                        IdConta = c.IdConta,
                        Valor = c.Valor,
                        ValorItens = c.ValorItens,
                        FkReservasIdReserva = c.FkReservasIdReserva
                    })
                    .ToList();

                return contas;
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetContaById(int id)
        {
            using (var _context = new HotelMaiorContext())
            {
                var conta = _context.Conta
                    .Where(c => c.IdConta == id)
                    .Select(c => new ContaDTO
                    {
                        IdConta = c.IdConta,
                        Valor = c.Valor,
                        ValorItens = c.ValorItens,
                        FkReservasIdReserva = c.FkReservasIdReserva
                    })
                    .FirstOrDefault();

                if (conta == null)
                {
                    return NotFound(); 
                }

                return Ok(conta);
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutConta(int id, [FromBody] ContaDTO contaDTO)
        {
            using (var _context = new HotelMaiorContext())
            {
                var conta = _context.Conta.Find(id);

                if (conta == null)
                {
                    return NotFound(); 
                }

                conta.Valor = contaDTO.Valor;
                conta.ValorItens = contaDTO.ValorItens;
                conta.FkReservasIdReserva = contaDTO.FkReservasIdReserva;

                _context.SaveChanges();

                return Ok(); 
            }
        }


        [HttpPost]
        public void PostConta([FromBody] ContaDTO contaDTO)
        {
            using (var _context = new HotelMaiorContext())
            {
                var conta = new Conta
                {
                    IdConta = contaDTO.IdConta,
                    FkReservasIdReserva = contaDTO.FkReservasIdReserva
                };

                _context.Conta.Add(conta);
                _context.SaveChanges();
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteConta(int id)
        {
            using (var _context = new HotelMaiorContext())
            {
                var conta = _context.Conta.Find(id);

                if (conta == null)
                {
                    return NotFound(); 
                }

                _context.Conta.Remove(conta);
                _context.SaveChanges();

                return NoContent(); 
            }
        }


    }
}
