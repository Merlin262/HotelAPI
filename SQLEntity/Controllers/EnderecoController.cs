using Microsoft.AspNetCore.Mvc;
using SQLEntity.NovaPasta;

namespace SQLEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {

        private readonly HotelMaiorContext _context;

        public EnderecoController(HotelMaiorContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Endereco>> GetEnderecos()
        {
            return _context.Enderecos.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Endereco> GetEndereco(int id)
        {
            var endereco = _context.Enderecos.Find(id);

            if (endereco == null)
            {
                return NotFound();
            }

            return endereco;
        }


        [HttpPost]
        public void PostEndereco([FromBody] EnderecoDTO enderecoDTO)
        {
            using (var _context = new HotelMaiorContext())
            {
                Endereco endereco = new Endereco
                {
                    IdEndereco = enderecoDTO.IdEndereco,
                    Pais = enderecoDTO.Pais,
                    Estado = enderecoDTO.Estado,
                    Cidade = enderecoDTO.Cidade,
                    Rua = enderecoDTO.Rua,
                    Numero = enderecoDTO.Numero
                };

                _context.Enderecos.Add(endereco);
                _context.SaveChanges();
            }
        }




        [HttpPut("{id}")]
        public ActionResult PutEndereco(int id, [FromBody] EnderecoDTO enderecoDTO)
        {
            using (var _context = new HotelMaiorContext())
            {
                var enderecoExistente = _context.Enderecos.Find(id);

                if (enderecoExistente == null)
                {
                    return NotFound();
                }

                enderecoExistente.Pais = enderecoDTO.Pais;
                enderecoExistente.Estado = enderecoDTO.Estado;
                enderecoExistente.Cidade = enderecoDTO.Cidade;
                enderecoExistente.Rua = enderecoDTO.Rua;
                enderecoExistente.Numero = enderecoDTO.Numero;

                _context.SaveChanges();

                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEndereco(int id)
        {
            using (var _context = new HotelMaiorContext())
            {
                var enderecoExistente = _context.Enderecos.Find(id);

                if (enderecoExistente == null)
                {
                    return NotFound();
                }

                _context.Enderecos.Remove(enderecoExistente);
                _context.SaveChanges();

                return NoContent();
            }
        }
    }
}
