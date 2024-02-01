using Microsoft.AspNetCore.Mvc;
using SQLEntity.DTOs;

namespace SQLEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItensPedidosController : ControllerBase
    {
        private readonly HotelMaiorContext _context;

        public ItensPedidosController(HotelMaiorContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<ItensPedidoDTO> GetItensPedido()
        {
            using (var _context = new HotelMaiorContext())
            {
                var itensPedido = _context.ItensPedidos
                    .Select(ip => new ItensPedidoDTO
                    {
                        IdItemPedido = ip.IdItemPedido,
                        DescricaoItem = ip.DescricaoItem,
                        Quantidade = ip.Quantidade,
                        ValorItem = ip.ValorItem,
                        FkPedidosIdPedido = ip.FkPedidosIdPedido
                    })
                    .ToList();

                return itensPedido;
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetItensPedidoById(int id)
        {
            using (var _context = new HotelMaiorContext())
            {
                var itensPedido = _context.ItensPedidos
                    .Where(ip => ip.IdItemPedido == id)
                    .Select(ip => new ItensPedidoDTO
                    {
                        IdItemPedido = ip.IdItemPedido,
                        DescricaoItem = ip.DescricaoItem,
                        Quantidade = ip.Quantidade,
                        ValorItem = ip.ValorItem,
                        FkPedidosIdPedido = ip.FkPedidosIdPedido
                    })
                    .FirstOrDefault();

                if (itensPedido == null)
                {
                    return NotFound(); 
                }

                return Ok(itensPedido);
            }
        }


        [HttpPut("{id}")]
        public IActionResult PutItensPedido(int id, [FromBody] ItensPedidoDTO itensPedidoDTO)
        {
            using (var _context = new HotelMaiorContext())
            {
                var itensPedido = _context.ItensPedidos.Find(id);

                if (itensPedido == null)
                {
                    return NotFound(); 
                }

                itensPedido.IdItemPedido = itensPedidoDTO.IdItemPedido;
                itensPedido.DescricaoItem = itensPedidoDTO.DescricaoItem;
                itensPedido.Quantidade = itensPedidoDTO.Quantidade;
                itensPedido.ValorItem = itensPedidoDTO.ValorItem;
                itensPedido.FkPedidosIdPedido = itensPedidoDTO.FkPedidosIdPedido;

                _context.SaveChanges();

                return Ok(); 
            }
        }


        [HttpPost]
        public void PostItensPedido([FromBody] ItensPedidoDTO itensPedidoDTO)
        {
            using (var _context = new HotelMaiorContext())
            {
                var itensPedido = new ItensPedido
                {
                    IdItemPedido = itensPedidoDTO.IdItemPedido,
                    DescricaoItem = itensPedidoDTO.DescricaoItem,
                    Quantidade = itensPedidoDTO.Quantidade,
                    ValorItem = itensPedidoDTO.ValorItem,
                    FkPedidosIdPedido = itensPedidoDTO.FkPedidosIdPedido
                };

                _context.ItensPedidos.Add(itensPedido);
                _context.SaveChanges();
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteItensPedido(int id)
        {
            using (var _context = new HotelMaiorContext())
            {
                var itensPedido = _context.ItensPedidos.Find(id);

                if (itensPedido == null)
                {
                    return NotFound(); 
                }

                _context.ItensPedidos.Remove(itensPedido);
                _context.SaveChanges();

                return NoContent(); 
            }
        }

    }
}
