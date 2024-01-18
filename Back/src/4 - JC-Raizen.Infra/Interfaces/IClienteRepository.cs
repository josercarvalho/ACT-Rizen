using JC_Raizen.Domain.Entidades;
using JC_Raizen.Infra.Models;

namespace JC_Raizen.Infra.Interfaces
{
    public interface IClienteRepository : IGenericRepository
    {
        Task<PageList<Cliente>> GetAllAsync(PageParams pageParams);
        Task<Cliente> GetByIdAsync(int Id);
        Task<Cliente> GetByNameAsync(string name);

    }
}
