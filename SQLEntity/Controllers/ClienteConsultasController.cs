using Microsoft.AspNetCore.Mvc;

namespace SQLEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteConsultasController : ControllerBase
    {
        private readonly HotelMaiorContext _context;

        public ClienteConsultasController(HotelMaiorContext context)
        {
            _context = context;
        }

        [HttpGet("ObterInformacoesQuarto/{numeroQuarto}")]
        public ActionResult<string> ObterInformacoesQuarto(int numeroQuarto)
        {
            try
            {
                var resultado = _context.TiposQuartos
                    .Join(_context.Quartos,
                        tipoQuarto => tipoQuarto.IdQuarto,
                        quarto => quarto.FkTiposQuartoIdQuarto,
                        (tipoQuarto, quarto) => new
                        {
                            tipoQuarto.DescricaoQuarto,
                            ValorQuarto = tipoQuarto.ValorQuarto ?? 0,
                            quarto.NumeroQuarto
                        })
                    .Where(combined => combined.NumeroQuarto == numeroQuarto)
                    .FirstOrDefault();

                if (resultado != null)
                {
                    string descricaoQuarto = resultado.DescricaoQuarto;
                    decimal valorQuarto = resultado.ValorQuarto;

                    string resposta = $"Descrição do Quarto: {descricaoQuarto}, Valor do Quarto: {valorQuarto}";
                    return Ok(resposta);
                }
                else
                {
                    return NotFound("Quarto não encontrado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }




        [HttpGet("ObterInformacoesLavanderia")]
        public ActionResult<IEnumerable<object>> ObterInformacoesLavanderia()
        {
            try
            {
                var resultados = _context.Lavanderia
                    .Select(lavanderia => new
                    {
                        lavanderia.IdLavanderia,
                        lavanderia.DescricaoServico,
                        ValorServico = lavanderia.ValorServico ?? 0 
                    })
                    .ToList();

                return Ok(resultados);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }




        [HttpGet("ObterInformacoesEstadiaCliente/{idCliente}")]
        public ActionResult<IEnumerable<object>> ObterInformacoesEstadiaCliente(int idCliente)
        {
            try
            {
                var resultados = _context.Reservas
                    .Where(reserva => reserva.FkClientesIdCliente == idCliente)
                    .Select(reserva => new
                    {
                        reserva.IdReserva,
                        reserva.CheckIn,
                        reserva.CheckOut,
                        reserva.Cancelado,
                        reserva.Valor,
                        reserva.NumPessoas,
                        NomeFuncionario = reserva.FkFuncionariosIdFuncionarioNavigation.NomeFuncionario
                    })
                    .ToList();

                return Ok(resultados);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }




        [HttpGet("ObterQuartosDisponiveisNaCidade/{cidade}")]
        public ActionResult<IEnumerable<object>> ObterQuartosDisponiveisNaCidade(string cidade)
        {
            try
            {
                var resultados = _context.Quartos
                    .Where(quarto => quarto.FkReservasIdReservaNavigation == null &&
                                     quarto.FkFiliaisIdFilialNavigation.FkEnderecoIdEnderecoNavigation.Cidade == cidade)
                    .Select(quarto => new
                    {
                        quarto.NumeroQuarto,
                        quarto.CapacidadeMaxima,
                        quarto.Adaptavel
                    })
                    .ToList();

                return Ok(resultados);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }



        [HttpGet("ObterInformacoesItens")]
        public ActionResult<IEnumerable<object>> ObterInformacoesItens()
        {
            try
            {
                var resultados = _context.Itens
                    .Select(item => new
                    {
                        item.IdItens,
                        item.DescricaoItem,
                        item.ValorItem
                    })
                    .ToList();

                return Ok(resultados);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}
