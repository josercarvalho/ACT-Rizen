using JC_Raizen.Infra.Models;
using JC_Raizen.Services.DTO;

namespace JC_Raizen.Services.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteDTO> AddClientes(ClienteDTO model);
        Task<ClienteDTO> UpdateCliente(int Id, ClienteDTO model);
        Task<bool> DeleteCliente(int Id);
        Task<ClienteDTO> GetClienteByIdAsync(int Id);
        Task<PageList<ClienteDTO>> GetAllClientesAsync(PageParams pageParams);
    }
}