using JC_Raizen.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace JC_Raizen.API.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly IViaCepApi _viaCepApi;

        public EnderecoController(IViaCepApi viaCepApi)
        {
            _viaCepApi = viaCepApi;
        }

        [HttpGet("{codigoCep}")]
        public async Task<IActionResult> BuscarTabela([RegularExpression("^[0-9]*$")] string codigoCep)
        {
            try
            {
                var retorno = await _viaCepApi.BuscarPorCodigo(codigoCep);

                if (retorno.CodigoHttp == HttpStatusCode.OK)
                {
                    return Ok(retorno.DadosRetorno);
                }
                else
                {
                    return StatusCode((int)retorno.CodigoHttp, retorno.ErroRetorno);
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar buscar o CEP. Erro: {ex.Message}");
            }
        }
    }
}
