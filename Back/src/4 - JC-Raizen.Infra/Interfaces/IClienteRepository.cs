using JC_Raizen.Domain.Entidades;

namespace JC_Raizen.Infra.Interfaces
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Task<Cliente> GetByEmail(string email);
        Task<List<Cliente>> SearchByEmail(string email);
        Task<List<Cliente>> SearchByName(string nome);
    }
}
