using Microsoft.AspNetCore.Mvc;

namespace SQLEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GerenciaController : ControllerBase
    {

        private readonly HotelMaiorContext _context;

        public GerenciaController(HotelMaiorContext context)
        {
            _context = context;
        }


        [HttpPost("calcular-valor-conta")]
        public IActionResult CalcularValorConta(int idReserva, int idFilial, int numeroQuarto)
        {
            try
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var result = _context.Database.ExecuteSqlInterpolated($@"
                    EXEC CalcularEAtualizarReserva {idReserva}, {idFilial}, {numeroQuarto}
                ");

                        transaction.Commit();
                        return Ok($"Operação concluída com sucesso. Linhas afetadas: {result}");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return BadRequest("Erro ao executar a operação: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao executar a operação: " + ex.Message);
            }
        }


        [HttpPost("atualizar-valor-itens-conta")]
        public IActionResult AtualizarValorItensConta(int idReserva, int idCliente)
        {
            try
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var result = _context.Database.ExecuteSqlInterpolated($@"
                    EXEC AtualizarValorItensConta {idReserva}, {idCliente}
                ");

                        transaction.Commit();
                        return Ok($"Operação concluída com sucesso. Linhas afetadas: {result}");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return BadRequest("Erro ao executar a operação: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao executar a operação: " + ex.Message);
            }
        }



        [HttpPost("atualizar-valor-total-nota-fiscal")]
        public IActionResult AtualizarValorTotalNotaFiscal(int codigoNotaFiscal)
        {
            try
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var result = _context.Database.ExecuteSqlInterpolated($@"
                    EXEC AtualizarValorTotalNotaFiscal {codigoNotaFiscal}
                ");

                        transaction.Commit();
                        return Ok($"Operação concluída com sucesso. Linhas afetadas: {result}");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return BadRequest("Erro ao executar a operação: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao executar a operação: " + ex.Message);
            }
        }
    }
}
