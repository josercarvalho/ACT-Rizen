using JC_Raizen.Domain.Entidades;
using JC_Raizen.Services.DTO;
using JC_Raizen.Services.Interfaces;
using System.Dynamic;
using System.Text.Json;

namespace JC_Raizen.Services.Rest
{
    public class ViaCepApiRest : IViaCepApi
    {
        public async Task<ResponseGenerico<Endereco>> BuscarPorCodigo(string cep)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://viacep.com.br/ws/{cep}/json/");

            var response = new ResponseGenerico<Endereco>();
            using (var client = new HttpClient())
            {
                var responseBrasilApi = await client.SendAsync(request);
                var contentResp = await responseBrasilApi.Content.ReadAsStringAsync();
                var objResponse = JsonSerializer.Deserialize<Endereco>(contentResp);

                if (responseBrasilApi.IsSuccessStatusCode)
                {
                    response.CodigoHttp = responseBrasilApi.StatusCode;
                    response.DadosRetorno = objResponse;
                }
                else
                {
                    response.CodigoHttp = responseBrasilApi.StatusCode;
                    response.ErroRetorno = JsonSerializer.Deserialize<ExpandoObject>(contentResp);
                }
            }
            return response;
        }
    }
}
