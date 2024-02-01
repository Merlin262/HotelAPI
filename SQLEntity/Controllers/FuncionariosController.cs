using Microsoft.AspNetCore.Mvc;
using SQLEntity.DTOs;

namespace SQLEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly HotelMaiorContext _context;

        public FuncionariosController(HotelMaiorContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Funcionario> GetFuncionarios()
        {
            using (var _context = new HotelMaiorContext())
            {
                return _context.Funcionarios.ToList();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetFuncionarioById(int id)
        {
            using (var _context = new HotelMaiorContext())
            {
                var funcionario = _context.Funcionarios
                    .Where(f => f.IdFuncionario == id)
                    .FirstOrDefault();

                if (funcionario == null)
                {
                    return NotFound();
                }

                return new ObjectResult(new FuncionarioDTO
                {
                    IdFuncionario = funcionario.IdFuncionario,
                    NomeFuncionario = funcionario.NomeFuncionario,
                    FkFiliaisIdFilial = funcionario.FkFiliaisIdFilial,
                    FkTipoFuncionarioIdTipoFuncionario = funcionario.FkTipoFuncionarioIdTipoFuncionario
                });
            }
        }

    
        [HttpPut("{id}")]
        public void PutFuncionario(int id, [FromBody] FuncionarioDTO funcionarioDTO)
        {
            using (var _context = new HotelMaiorContext())
            {
                var funcionario = _context.Funcionarios.Find(id);

                if (funcionario != null)
                {
                    funcionario.NomeFuncionario = funcionarioDTO.NomeFuncionario;
                    funcionario.FkFiliaisIdFilial = funcionarioDTO.FkFiliaisIdFilial;
                    funcionario.FkTipoFuncionarioIdTipoFuncionario = funcionarioDTO.FkTipoFuncionarioIdTipoFuncionario;

                    _context.SaveChanges();
                }
            }
        }

        [HttpPost]
        public void PostFuncionario([FromBody] FuncionarioDTO funcionarioDTO)
        {
            using (var _context = new HotelMaiorContext())
            {
                var funcionario = new Funcionario
                {
                    IdFuncionario = funcionarioDTO.IdFuncionario,
                    NomeFuncionario = funcionarioDTO.NomeFuncionario,
                    FkFiliaisIdFilial = funcionarioDTO.FkFiliaisIdFilial,
                    FkTipoFuncionarioIdTipoFuncionario = funcionarioDTO.FkTipoFuncionarioIdTipoFuncionario
                };

                _context.Funcionarios.Add(funcionario);
                _context.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void DeleteFuncionario(int id)
        {
            using (var _context = new HotelMaiorContext())
            {
                var funcionario = _context.Funcionarios.Find(id);

                if (funcionario != null)
                {
                    _context.Funcionarios.Remove(funcionario);
                    _context.SaveChanges();
                }
            }
        }

        
    }
}
