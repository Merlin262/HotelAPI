using Microsoft.AspNetCore.Mvc;
using SQLEntity.DTOs;

namespace SQLEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilialsController : ControllerBase
    {
        private readonly HotelMaiorContext _context;

        public FilialsController(HotelMaiorContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<FilialDTO> GetFiliais()
        {
            using (var _context = new HotelMaiorContext())
            {
                var filiais = _context.Filiais
                    .Select(f => new FilialDTO
                    {
                        NomeFilial = f.NomeFilial,
                        NumeroQuartos = f.NumeroQuartos,
                        QtdEstrelas = f.QtdEstrelas,
                        CoeficienteFilialPreco = f.CoeficienteFilialPreco,
                        IdFilial = f.IdFilial,
                        FkEnderecoIdEndereco = f.FkEnderecoIdEndereco
                    })
                    .ToList();

                return filiais;
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetFilialById(int id)
        {
            using (var _context = new HotelMaiorContext())
            {
                var filial = _context.Filiais
                    .Where(f => f.IdFilial == id)
                    .Select(f => new FilialDTO
                    {
                        NomeFilial = f.NomeFilial,
                        NumeroQuartos = f.NumeroQuartos,
                        QtdEstrelas = f.QtdEstrelas,
                        CoeficienteFilialPreco = f.CoeficienteFilialPreco,
                        IdFilial = f.IdFilial,
                        FkEnderecoIdEndereco = f.FkEnderecoIdEndereco
                    })
                    .FirstOrDefault();

                if (filial == null)
                {
                    return NotFound(); 
                }

                return Ok(filial);
            }
        }

        
        [HttpPut("{id}")]
        public IActionResult PutFilial(int id, [FromBody] FilialDTO filialDTO)
        {
            using (var _context = new HotelMaiorContext())
            {
                var filial = _context.Filiais.Find(id);

                if (filial == null)
                {
                    return NotFound(); 
                }

                filial.NomeFilial = filialDTO.NomeFilial;
                filial.NumeroQuartos = filialDTO.NumeroQuartos;
                filial.QtdEstrelas = filialDTO.QtdEstrelas;
                filial.CoeficienteFilialPreco = filialDTO.CoeficienteFilialPreco;
                filial.FkEnderecoIdEndereco = filialDTO.FkEnderecoIdEndereco;

                _context.SaveChanges();

                return Ok(); 
            }
        }

        [HttpPost]
        public void PostFilial([FromBody] FilialDTO filialDTO)
        {
            using (var _context = new HotelMaiorContext())
            {
                var filial = new Filial
                {
                    NomeFilial = filialDTO.NomeFilial,
                    NumeroQuartos = filialDTO.NumeroQuartos,
                    QtdEstrelas = filialDTO.QtdEstrelas,
                    CoeficienteFilialPreco = filialDTO.CoeficienteFilialPreco,
                    IdFilial = filialDTO.IdFilial,
                    FkEnderecoIdEndereco = filialDTO.FkEnderecoIdEndereco
                };

                _context.Filiais.Add(filial);
                _context.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFilial(int id)
        {
            using (var _context = new HotelMaiorContext())
            {
                var filial = _context.Filiais.Find(id);

                if (filial == null)
                {
                    return NotFound(); 
                }

                _context.Filiais.Remove(filial);
                _context.SaveChanges();

                return NoContent(); 
            }
        }

    }
}
