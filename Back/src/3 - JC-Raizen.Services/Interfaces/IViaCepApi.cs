using JC_Raizen.Domain.Entidades;
using JC_Raizen.Services.DTO;

namespace JC_Raizen.Services.Interfaces
{
    public interface IViaCepApi
    {
        Task<ResponseGenerico<Endereco>> BuscarPorCodigo(string cep);
    }
}
