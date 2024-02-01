using Microsoft.AspNetCore.Mvc;
using SQLEntity.DTOs;



namespace SQLEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private readonly HotelMaiorContext _context;

        public ReservasController(HotelMaiorContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<ReservaDTO> GetReservas()
        {
            using (var _context = new HotelMaiorContext())
            {
                var reservas = _context.Reservas
                    .Select(r => new ReservaDTO
                    {
                        IdReserva = r.IdReserva,
                        CheckIn = r.CheckIn,
                        CheckOut = r.CheckOut,
                        Cancelado = r.Cancelado,
                        Valor = r.Valor,
                        NumPessoas = r.NumPessoas,
                        FkClientesIdCliente = r.FkClientesIdCliente,
                        FkFuncionariosIdFuncionario = r.FkFuncionariosIdFuncionario
                    })
                    .ToList();

                return reservas;
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetReservaById(int id)
        {
            using (var _context = new HotelMaiorContext())
            {
                var reserva = _context.Reservas
                    .Where(r => r.IdReserva == id)
                    .Select(r => new ReservaDTO
                    {
                        IdReserva = r.IdReserva,
                        CheckIn = r.CheckIn,
                        CheckOut = r.CheckOut,
                        Cancelado = r.Cancelado,
                        Valor = r.Valor,
                        NumPessoas = r.NumPessoas,
                        FkClientesIdCliente = r.FkClientesIdCliente,
                        FkFuncionariosIdFuncionario = r.FkFuncionariosIdFuncionario
                    })
                    .FirstOrDefault();

                if (reserva == null)
                {
                    return NotFound(); 
                }

                return Ok(reserva);
            }
        }


        [HttpPut("{id}")]
        public IActionResult PutReserva(int id, [FromBody] ReservaDTO reservaDTO)
        {
            using (var _context = new HotelMaiorContext())
            {
                var reserva = _context.Reservas.Find(id);

                if (reserva == null)
                {
                    return NotFound(); 
                }

                var clienteExistente = _context.Clientes.Find(reservaDTO.FkClientesIdCliente);

                if (clienteExistente == null)
                {
                    return BadRequest("O cliente especificado não existe.");
                }

                var funcionarioExistente = _context.Funcionarios.Find(reservaDTO.FkFuncionariosIdFuncionario);

                if (funcionarioExistente == null)
                {
                    return BadRequest("O funcionário especificado não existe.");
                }

                reserva.CheckIn = reservaDTO.CheckIn;
                reserva.CheckOut = reservaDTO.CheckOut;
                reserva.Cancelado = reservaDTO.Cancelado;
                reserva.Valor = reservaDTO.Valor;
                reserva.NumPessoas = reservaDTO.NumPessoas;
                reserva.FkClientesIdCliente = reservaDTO.FkClientesIdCliente;
                reserva.FkFuncionariosIdFuncionario = reservaDTO.FkFuncionariosIdFuncionario;

                _context.SaveChanges();

                return Ok("Reserva atualizada com sucesso.");
            }
        }


        [HttpPost]
        public IActionResult PostReserva([FromBody] ReservaDTO reservaDTO)
        {
            using (var _context = new HotelMaiorContext())
            {
                var clienteExistente = _context.Clientes.Find(reservaDTO.FkClientesIdCliente);

                if (clienteExistente == null)
                {
                    return BadRequest("O cliente especificado não existe.");
                }

                var funcionarioExistente = _context.Funcionarios.Find(reservaDTO.FkFuncionariosIdFuncionario);

                if (funcionarioExistente == null)
                {
                    return BadRequest("O funcionário especificado não existe.");
                }

                var reserva = new Reserva
                {
                    IdReserva = reservaDTO.IdReserva,
                    CheckIn = reservaDTO.CheckIn,
                    CheckOut = reservaDTO.CheckOut,
                    Cancelado = reservaDTO.Cancelado,
                    Valor = reservaDTO.Valor,
                    NumPessoas = reservaDTO.NumPessoas,
                    FkClientesIdCliente = reservaDTO.FkClientesIdCliente,
                    FkFuncionariosIdFuncionario = reservaDTO.FkFuncionariosIdFuncionario
                };

                _context.Reservas.Add(reserva);
                _context.SaveChanges();

                return Ok("Reserva adicionada com sucesso.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReserva(int id)
        {
            using (var _context = new HotelMaiorContext())
            {
                var reserva = _context.Reservas.Find(id);

                if (reserva == null)
                {
                    return NotFound(); 
                }

                _context.Reservas.Remove(reserva);
                _context.SaveChanges();

                return Ok("Reserva excluída com sucesso.");
            }
        }

    }
}
