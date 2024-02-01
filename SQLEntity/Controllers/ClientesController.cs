using Microsoft.AspNetCore.Mvc;
using SQLEntity.DTOs;

namespace SQLEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly HotelMaiorContext _context;

        public ClientesController(HotelMaiorContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<ClienteDTO> GetClientes()
        {
            using (var _context = new HotelMaiorContext())
            {
                var clientes = _context.Clientes
                    .Select(c => new ClienteDTO
                    {
                        IdCliente = c.IdCliente,
                        NomeCliente = c.NomeCliente,
                        Nacionalidade = c.Nacionalidade,
                        EmailCliente = c.EmailCliente,
                        TelefoneCliente = c.TelefoneCliente,
                        FkEnderecoIdEndereco = c.FkEnderecoIdEndereco
                    })
                    .ToList();

                return clientes;
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetClienteById(int id)
        {
            using (var _context = new HotelMaiorContext())
            {
                var cliente = _context.Clientes
                    .Where(c => c.IdCliente == id)
                    .Select(c => new ClienteDTO
                    {
                        IdCliente = c.IdCliente,
                        NomeCliente = c.NomeCliente,
                        Nacionalidade = c.Nacionalidade,
                        EmailCliente = c.EmailCliente,
                        TelefoneCliente = c.TelefoneCliente,
                        FkEnderecoIdEndereco = c.FkEnderecoIdEndereco
                    })
                    .FirstOrDefault();

                if (cliente == null)
                {
                    return NotFound(); 
                }

                return Ok(cliente);
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutCliente(int id, [FromBody] ClienteDTO clienteDTO)
        {
            using (var _context = new HotelMaiorContext())
            {
                var cliente = _context.Clientes.Find(id);

                if (cliente == null)
                {
                    return NotFound(); 
                }

                cliente.NomeCliente = clienteDTO.NomeCliente;
                cliente.Nacionalidade = clienteDTO.Nacionalidade;
                cliente.EmailCliente = clienteDTO.EmailCliente;
                cliente.TelefoneCliente = clienteDTO.TelefoneCliente;
                cliente.FkEnderecoIdEndereco = clienteDTO.FkEnderecoIdEndereco;

                _context.SaveChanges();

                return Ok(); 
            }  
        }

        [HttpPost]
        public void PostCliente([FromBody] ClienteDTO clienteDTO)
        {
            using (var _context = new HotelMaiorContext())
            {
                var cliente = new Cliente
                {
                    IdCliente = clienteDTO.IdCliente,
                    NomeCliente = clienteDTO.NomeCliente,
                    Nacionalidade = clienteDTO.Nacionalidade,
                    EmailCliente = clienteDTO.EmailCliente,
                    TelefoneCliente = clienteDTO.TelefoneCliente,
                    FkEnderecoIdEndereco = clienteDTO.FkEnderecoIdEndereco
                };

                _context.Clientes.Add(cliente);
                _context.SaveChanges();
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(int id)
        {
            using (var _context = new HotelMaiorContext())
            {
                var cliente = _context.Clientes.Find(id);

                if (cliente == null)
                {
                    return NotFound(); 
                }

                _context.Clientes.Remove(cliente);
                _context.SaveChanges();

                return NoContent(); 
            }
        }

    }
}
