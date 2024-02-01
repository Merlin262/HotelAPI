using Microsoft.AspNetCore.Mvc;
using SQLEntity.DTOs;

namespace SQLEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoesController : ControllerBase
    {
        private readonly HotelMaiorContext _context;

        public PedidoesController(HotelMaiorContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<PedidoDTO> GetPedidos()
        {
            using (var _context = new HotelMaiorContext())
            {
                var pedidos = _context.Pedidos
                    .Select(p => new PedidoDTO
                    {
                        IdPedido = p.IdPedido,
                        DataPedido = p.DataPedido,
                        FkClientesIdCliente = p.FkClientesIdCliente
                    })
                    .ToList();

                return pedidos;
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetPedidoById(int id)
        {
            using (var _context = new HotelMaiorContext())
            {
                var pedido = _context.Pedidos
                    .Where(p => p.IdPedido == id)
                    .Select(p => new PedidoDTO
                    {
                        IdPedido = p.IdPedido,
                        DataPedido = p.DataPedido,
                        FkClientesIdCliente = p.FkClientesIdCliente
                    })
                    .FirstOrDefault();

                if (pedido == null)
                {
                    return NotFound(); 

                }
                return Ok(pedido);
                
            }
        }


        [HttpPut("{id}")]
        public IActionResult PutPedido(int id, [FromBody] PedidoDTO pedidoDTO)
        {
            using (var _context = new HotelMaiorContext())
            {
                var pedido = _context.Pedidos.Find(id);

                if (pedido == null)
                {
                    return NotFound(); 
                }

                pedido.DataPedido = pedidoDTO.DataPedido;
                pedido.FkClientesIdCliente = pedidoDTO.FkClientesIdCliente;

                _context.SaveChanges();

                return Ok(); 
            }
        }


        [HttpPost]
        public void PostPedido([FromBody] PedidoDTO pedidoDTO)
        {
            using (var _context = new HotelMaiorContext())
            {
                var pedido = new Pedido
                {
                    IdPedido = pedidoDTO.IdPedido,
                    DataPedido = pedidoDTO.DataPedido,
                    FkClientesIdCliente = pedidoDTO.FkClientesIdCliente
                };

                _context.Pedidos.Add(pedido);
                _context.SaveChanges();
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeletePedido(int id)
        {
            using (var _context = new HotelMaiorContext())
            {
                var pedido = _context.Pedidos.Find(id);

                if (pedido == null)
                {
                    return NotFound(); 
                }

                _context.Pedidos.Remove(pedido);
                _context.SaveChanges();

                return NoContent(); 
            }
        }


        
    }
}
