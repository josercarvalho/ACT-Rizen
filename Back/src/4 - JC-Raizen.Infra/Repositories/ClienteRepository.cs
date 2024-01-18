using JC_Raizen.Domain.Entidades;
using JC_Raizen.Infra.Context;
using JC_Raizen.Infra.Interfaces;
using JC_Raizen.Infra.Models;
using Microsoft.EntityFrameworkCore;

namespace JC_Raizen.Infra.Repositories
{
    public class ClienteRepository : GenericRepository, IClienteRepository
    {
        private readonly Contexto _contexto;

        public ClienteRepository(Contexto context) : base(context)
        {
            _contexto = context;
        }

        public async Task<PageList<Cliente>> GetAllAsync(PageParams pageParams)
        {
            IQueryable<Cliente> query = _contexto.Clientes;

            query = query.AsNoTracking()
                            .OrderBy(e => e.Id);

            return await PageList<Cliente>.CreateAsync(query, pageParams.PageNumber, pageParams.pageSize);

        }

        public async Task<Cliente> GetByIdAsync(int Id)
        {
            IQueryable<Cliente> query = _contexto.Clientes;


            query = query.AsNoTracking()
                            .OrderBy(e => e.Id)
                            .Where(e => e.Id == Id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Cliente> GetByNameAsync(string name)
        {
            IQueryable<Cliente> query = _contexto.Clientes;


            query = query.AsNoTracking()
                            .OrderBy(e => e.Id)
                            .Where(e => e.Nome == name);

            return await query.FirstOrDefaultAsync();
        }
    }
}
