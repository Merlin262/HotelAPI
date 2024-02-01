using Microsoft.AspNetCore.Mvc;
using SQLEntity.DTOs;

namespace SQLEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoFuncionariosController : ControllerBase
    {
        private readonly HotelMaiorContext _context;

        public TipoFuncionariosController(HotelMaiorContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TipoFuncionario>> GetTipoFuncionarios()
        {
            return _context.TipoFuncionarios.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<TipoFuncionario> GetTipoFuncionario(int id)
        {
            var tipoFuncionario = _context.TipoFuncionarios.Find(id);

            if (tipoFuncionario == null)
            {
                return NotFound();
            }

            return tipoFuncionario;
        }


        [HttpPost]
        public void PostTipoFuncionario([FromBody] TipoFuncionarioDTO tipoFuncionarioDTO)
        {
            using (var _context = new HotelMaiorContext())
            {
                TipoFuncionario tipo = new TipoFuncionario
                {
                    IdTipoFuncionario = tipoFuncionarioDTO.IdTipoFuncionario,
                    Descricao = tipoFuncionarioDTO.Descricao
                };

                _context.TipoFuncionarios.Add(tipo);
                _context.SaveChanges();
            }
        }

        [HttpPut("{id}")]
        public void PutTipoFuncionario(int id, [FromBody] TipoFuncionarioDTO tipoFuncionarioDTO)
        {
            using (var _context = new HotelMaiorContext())
            {
                var tipoFuncionario = _context.TipoFuncionarios.Find(id);

                if (tipoFuncionario != null)
                {
                    tipoFuncionario.Descricao = tipoFuncionarioDTO.Descricao;
                    _context.SaveChanges();
                }
            }
        }

        [HttpDelete("{id}")]
        public void DeleteTipoFuncionario(int id)
        {
            using (var _context = new HotelMaiorContext())
            {
                var tipoFuncionario = _context.TipoFuncionarios.Find(id);

                if (tipoFuncionario != null)
                {
                    _context.TipoFuncionarios.Remove(tipoFuncionario);
                    _context.SaveChanges();
                }
            }
        }

        
    }

}
